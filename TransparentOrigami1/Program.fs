module AdventOfCode21.TransparentOrigami1.Program

open System
open AdventOfCode21
open AdventOfCode21.TransparentOrigami1.Parsing
open AdventOfCode21.TransparentOrigami1.Paper

let tryParseInput args =
    args
    |> Array.tryItem 0
    |> Option.asResult "Invalid number of args"
    |> Result.bind IO.tryReadLines
    |> Result.bindOption tryParseInput "Could not parse readings"
    |> Result.map (mapSnd List.head)

let analyze (paper, fold) = paper |> foldPaper fold |> countDots

[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map analyze
    |> Console.printResult
