module AdventOfCode21.Binary

open AdventOfCode21

let binToDec digits =

    let (^) b n =
        if n = 0 then 1L
        elif n >= 1 then List.replicate n b |> List.mult
        else 0L

    let digitToDec i digit = ((int64 digit) * (2L ^ i))

    digits |> List.rev |> List.mapi digitToDec |> List.sum
