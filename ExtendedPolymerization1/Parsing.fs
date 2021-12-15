module AdventOfCode21.ExtendedPolymerization1.Parsing

open AdventOfCode21
open AdventOfCode21.ExtendedPolymerization1.Polymer
open Microsoft.FSharp.Collections

let tryParseInput lines : (ElementMap * InsertionRule list) option =

    let templateLine = lines |> List.head
    let ruleLines = lines |> List.skip 2

    let parseMap line : ElementMap =

        let addPair map pair = map |> Map.mapAtOrAdd pair (fun i -> i + 1UL) 1UL

        let addTerminatorPair map = map |> Map.add (line |> Seq.last, '/') 1UL

        line
        |> Seq.pairwise
        |> Seq.fold addPair Map.empty
        |> addTerminatorPair

    let tryParseRule line : InsertionRule option =
        opt {
            let! f = line |> String.tryGet 0
            let! s = line |> String.tryGet 1
            let! ins = line |> String.tryGet 6

            return { Pair = (f, s); Replacement = ins }
        }

    opt {
        let map = templateLine |> parseMap
        let! rules = ruleLines |> List.map tryParseRule |> Option.collect
        return map, rules
    }
