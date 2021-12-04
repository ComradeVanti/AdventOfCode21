module AdventOfCode21.Parsing

let tryParseInt (s: string) =
    try
        s |> int |> Some
    with
    | _ -> None
