module AdventOfCode21.HydrothermalVenture1.Program

open System
open AdventOfCode21
open AdventOfCode21.Line
open AdventOfCode21.HydrothermalVenture1.Parsing
open AdventOfCode21.HydrothermalVenture1.VentDanger

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
    |> Result.map (List.filter (fun l -> l |> isVertical || l |> isHorizontal))
    |> Result.map calcDanger
    |> Console.printResult
