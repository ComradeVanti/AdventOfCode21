module AdventOfCode21.ExtendedPolymerization1.Polymer

open AdventOfCode21

type Element = char

type Polymer = Elements of Element list

type InsertionRule = { A: Element; B: Element; Res: Element }


let elements (Elements elements) = elements

let squash p1 p2 =
    List.append (p1 |> elements) (p2 |> elements |> List.skip 1)
    |> Elements

let grow rules polymer =

    let tryGetNewElement (e1, e2) =
        rules
        |> List.tryFind (fun rule -> rule.A = e1 && rule.B = e2)
        |> Option.map (fun rule -> rule.Res)

    let growPair (e1, e2) =
        tryGetNewElement (e1, e2)
        |> function
            | Some element -> [ e1; element; e2 ] |> Elements
            | None -> [ e1; e2 ] |> Elements

    polymer
    |> elements
    |> List.pairwise
    |> List.map growPair
    |> List.reduce squash

let mostCommonElement polymer =
    polymer |> elements |> List.sortByCount |> List.last

let leastCommonElement polymer =
    polymer |> elements |> List.sortByCount |> List.head

let countElement e polymer = polymer |> elements |> List.countItem e

let countMostCommonElement polymer =
    polymer |> countElement (polymer |> mostCommonElement)

let countLeastCommonElement polymer =
    polymer |> countElement (polymer |> leastCommonElement)
