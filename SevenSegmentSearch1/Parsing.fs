module AdventOfCode21.SevenSegmentSearch1.Parsing

open AdventOfCode21
open AdventOfCode21.SevenSegmentSearch1.SegmentClock

let tryParseInput lines =

    let tryParseSegment c =
        match c with
        | 'a' -> Some A
        | 'b' -> Some B
        | 'c' -> Some C
        | 'd' -> Some D
        | 'e' -> Some E
        | 'f' -> Some F
        | 'g' -> Some G
        | _ -> None

    let tryParseSignal s =
        s
        |> Seq.map tryParseSegment
        |> Option.collect
        |> Option.map Segments

    let tryParseSignals line =
        line
        |> String.splitAt '|'
        |> List.item 1
        |> String.splitAt ' '
        |> List.map tryParseSignal

    lines |> List.collect tryParseSignals |> Option.collect
