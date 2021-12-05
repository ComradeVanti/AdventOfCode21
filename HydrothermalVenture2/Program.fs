module AdventOfCode21.HydrothermalVenture2.Program

open System
open AdventOfCode21
open AdventOfCode21.HydrothermalVenture2.Parsing
open AdventOfCode21.HydrothermalVenture2.VentDanger

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
    |> Result.map calcDanger
    |> Console.printResult
