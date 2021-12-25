module AdventOfCode21.Binary

let binToDec digits =

    let (^) b n = int ((float b) ** (float n))

    let digitToDec i digit = int64 (digit * (2 ^ i))

    digits |> List.rev |> List.mapi digitToDec |> List.sum
