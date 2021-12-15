module AdventOfCode21.ExtendedPolymerization1.Polymer

open AdventOfCode21
open Microsoft.FSharp.Collections

type Element = char

type ElementPair = Element * Element

type PairCount = uint64

type ElementMap = Map<ElementPair, PairCount>

type InsertionRule = { Pair: ElementPair; Replacement: Element }


let newPairs rule : ElementPair * ElementPair =
    (rule.Pair |> fst, rule.Replacement), (rule.Replacement, rule.Pair |> snd)

let terminatorPair map =
    map
    |> Map.toList
    |> List.find (fst >> snd >> (=) '/')
    |> fst

let grow rules (map: ElementMap) : ElementMap =

    let countOf pair = map |> Map.tryFind pair |> Option.defaultValue 0UL

    let apply newMap rule =
        let count = countOf rule.Pair
        let p1, p2 = rule |> newPairs

        if count > 0UL then
            newMap
            |> Map.mapAtOrAdd p1 ((+) count) count
            |> Map.mapAtOrAdd p2 ((+) count) count
        else
            newMap

    let copyTerminatorPair newMap =
        newMap |> Map.add (map |> terminatorPair) 1UL

    rules |> List.fold apply Map.empty |> copyTerminatorPair

let elements elementMap =
    elementMap
    |> Map.toList
    |> List.map fst
    |> List.map fst
    |> List.distinct

let countElement element (elementMap: ElementMap) =
    elementMap
    |> Map.toList
    |> List.filter (fst >> fst >> (=) element)
    |> List.map (snd >> bigint)
    |> List.sum

let elementCounts elementMap =
    elementMap
    |> elements
    |> List.map (fun element -> elementMap |> countElement element)

let countMostCommonElement elementMap = elementMap |> elementCounts |> List.max

let countLeastCommonElement elementMap = elementMap |> elementCounts |> List.min
