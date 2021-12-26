module AdventOfCode21.PacketDecoder2.Program

open System
open AdventOfCode21
open AdventOfCode21.PacketDecoder2.Parsing
open AdventOfCode21.PacketDecoder2.Decode
open AdventOfCode21.PacketDecoder2.Calc
open Microsoft.FSharp.Core

let tryParseInput args =
    res {
        let! path =
            args
            |> Array.tryItem 0
            |> Option.asResult "Invalid number of args"

        let! text = IO.tryReadText path

        return!
            text
            |> tryParseInput
            |> Option.asResult "Could not parse input"
    }

[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.bind (tryDecode >> Option.asResult "Could not decode")
    |> Result.map calcValue
    |> Console.printResult
