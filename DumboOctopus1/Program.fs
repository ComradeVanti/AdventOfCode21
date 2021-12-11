module AdventOfCode21.DumboOctopus1.Program

open System
open AdventOfCode21
open AdventOfCode21.DumboOctopus1.Parsing
open AdventOfCode21.DumboOctopus1.OctopusPop

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



let trackFlashes pop =

    let rec trackUntilDone gen pop =
        if gen = 100 then
            0
        else
            let progressed = pop |> progress

            let flashes = progressed |> countFlashesInPrevStep

            flashes + (progressed |> trackUntilDone (gen + 1))

    trackUntilDone 0 pop


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map trackFlashes
    |> Console.printResult
