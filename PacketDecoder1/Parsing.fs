module AdventOfCode21.PacketDecoder1.Parsing

open AdventOfCode21
open AdventOfCode21.PacketDecoder1.Bin

let tryParseInput input =

    let tryParseHex c =
        match c with
        | '0' -> Some [ Bit.O; Bit.O; Bit.O; Bit.O ]
        | '1' -> Some [ Bit.O; Bit.O; Bit.O; Bit.I ]
        | '2' -> Some [ Bit.O; Bit.O; Bit.I; Bit.O ]
        | '3' -> Some [ Bit.O; Bit.O; Bit.I; Bit.I ]
        | '4' -> Some [ Bit.O; Bit.I; Bit.O; Bit.O ]
        | '5' -> Some [ Bit.O; Bit.I; Bit.O; Bit.I ]
        | '6' -> Some [ Bit.O; Bit.I; Bit.I; Bit.O ]
        | '7' -> Some [ Bit.O; Bit.I; Bit.I; Bit.I ]
        | '8' -> Some [ Bit.I; Bit.O; Bit.O; Bit.O ]
        | '9' -> Some [ Bit.I; Bit.O; Bit.O; Bit.I ]
        | 'A' -> Some [ Bit.I; Bit.O; Bit.I; Bit.O ]
        | 'B' -> Some [ Bit.I; Bit.O; Bit.I; Bit.I ]
        | 'C' -> Some [ Bit.I; Bit.I; Bit.O; Bit.O ]
        | 'D' -> Some [ Bit.I; Bit.I; Bit.O; Bit.I ]
        | 'E' -> Some [ Bit.I; Bit.I; Bit.I; Bit.O ]
        | 'F' -> Some [ Bit.I; Bit.I; Bit.I; Bit.I ]
        | _ -> None

    input
    |> Seq.map tryParseHex
    |> Option.collect
    |> Option.map (List.concat >> BitSequence)
