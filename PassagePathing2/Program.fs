module AdventOfCode21.PassagePathing2.Program

open System
open AdventOfCode21
open AdventOfCode21.PassagePathing2.Parsing
open AdventOfCode21.PassagePathing2.CaveSystem

let tryParseInput args =
    res {
        let! path =
            args
            |> Array.tryItem 0
            |> Option.asResult "Invalid number of args"

        let! lines = IO.tryReadLines path

        return!
            lines
            |> tryParseInput
            |> Option.asResult "Could not parse input"
    }


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map pathCount
    |> Console.printResult
