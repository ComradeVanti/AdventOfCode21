module AdventOfCode21.SevenSegmentSearch1.SegmentClock

type Segment =
    | A
    | B
    | C
    | D
    | E
    | F
    | G

type Signal = Segments of Segment list

type Digit = int


let tryParseDigit signal : Digit option =
    match signal with
    | Segments [ _; _ ] -> Some 1
    | Segments [ _; _; _ ] -> Some 7
    | Segments [ _; _; _; _ ] -> Some 4
    | Segments [ _; _; _; _; _; _; _ ] -> Some 8
    | _ -> None

let countKnownDigits signals =
    signals |> List.choose tryParseDigit |> List.length
