module AdventOfCode21.Chiton2.Program

open System
open AdventOfCode21
open AdventOfCode21.Chiton2.Parsing
open AdventOfCode21.Chiton2.Navigation

let tryParseInput args =
    args
    |> Array.tryItem 0
    |> Option.asResult "Invalid number of args"
    |> Result.bind IO.tryReadLines
    |> Result.bindOption tryParseInput "Could not parse readings"

let analyze map =
    let start = map |> Grid.topLeft
    let goal = map |> Grid.bottomRight
    map |> findBestPathBetween start goal |> cost

[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map analyze
    |> Console.printResult
