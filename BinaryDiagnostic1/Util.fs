module AdventOfCode21.BinaryDiagnostic1.Util

open AdventOfCode21.BinaryDiagnostic1.DiagnosticReport

let binToDec (bin: BinNum) =

    let (^) b n = int ((float b) ** (float n))

    let digitToDec i digit =
        match digit with
        | I -> (2 ^ i)
        | O -> 0

    bin |> List.rev |> List.mapi digitToDec |> List.sum
