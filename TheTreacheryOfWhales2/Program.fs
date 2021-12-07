module AdventOfCode21.TheTreacheryOfWhales2.Program

open System
open AdventOfCode21
open AdventOfCode21.TheTreacheryOfWhales2.Parsing
open AdventOfCode21.TheTreacheryOfWhales2.AlignNumbers

let tryParseInput args =
    res {
        let! path =
            args
            |> Array.tryItem 0
            |> Option.asResult "Invalid number of args"

        let! entries = IO.tryReadCSV path

        return!
            entries
            |> tryParseInput
            |> Option.asResult "Could not parse input"
    }


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map findMinimalAlignCost
    |> Console.printResult
