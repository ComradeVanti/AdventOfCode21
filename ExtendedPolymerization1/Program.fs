module AdventOfCode21.ExtendedPolymerization1.Program

open System
open AdventOfCode21
open AdventOfCode21.ExtendedPolymerization1.Parsing

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

let analyze (template, rules) =

    let rec growUntilDone step polymer =
        printfn $"%d{step}"

        if step = 40 then
            polymer
        else
            polymer |> Polymer.grow rules |> growUntilDone (step + 1)

    let grown = template |> growUntilDone 0
    let least = grown |> Polymer.countLeastCommonElement
    let most = grown |> Polymer.countMostCommonElement
    most - least


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.map analyze
    |> Console.printResult
