module AdventOfCode21.LanternFish1.Program

open System
open AdventOfCode21
open AdventOfCode21.PacketDecoder1.Parsing
open AdventOfCode21.PacketDecoder1.Decode

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

let private analyze bits =

    let rec addUpVersions =
        function
        | Number (v, _) -> v
        | Operator (v, sub) -> v + (sub |> List.map addUpVersions |> List.sum)

    bits
    |> tryDecode
    |> function
        | Some packet -> Ok(packet |> addUpVersions)
        | None -> Error "Tokens could not be parsed"


[<EntryPoint>]
let main args =
    args
    |> tryParseInput
    |> Result.bind analyze
    |> Console.printResult
