module AdventOfCode21.TransparentOrigami2.Program

open System
open AdventOfCode21
open AdventOfCode21.TransparentOrigami2.Parsing
open AdventOfCode21.TransparentOrigami2.Paper

let tryParseInput args =
    args
    |> Array.tryItem 0
    |> Option.asResult "Invalid number of args"
    |> Result.bind IO.tryReadLines
    |> Result.bindOption tryParseInput "Could not parse readings"

let analyze (paper, folds) =

    let doFold paper fold = paper |> foldPaper fold

    folds |> List.fold doFold paper |> toString

[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map analyze
    |> Console.printResult
