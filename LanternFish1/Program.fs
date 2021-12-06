module AdventOfCode21.LanternFish1.Program

open System
open AdventOfCode21
open AdventOfCode21.LanternFish1.Parsing
open AdventOfCode21.LanternFish1.FishSimulation

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

let private analyze pop =
    let rec progressUntilDone day pop =
        if day = 256 then
            pop |> fishCount
        else
            pop |> progress |> progressUntilDone (day + 1)

    pop |> progressUntilDone 0


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map analyze
    |> Console.printResult
