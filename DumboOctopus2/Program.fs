module AdventOfCode21.DumboOctopus2.Program

open System
open AdventOfCode21
open AdventOfCode21.DumboOctopus2.Parsing
open AdventOfCode21.DumboOctopus2.OctopusPop

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



let findFirstSynchronized pop =

    let rec progressUntilSynchronized pop =
        let progressed =
            pop
            |> progress
            
        if progressed |> isSynchronized then
            1
        else
            (progressed |> progressUntilSynchronized) + 1
            
    progressUntilSynchronized pop

[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map findFirstSynchronized
    |> Console.printResult
