module AdventOfCode21.PacketDecoder2.Calc

open AdventOfCode21
open AdventOfCode21.PacketDecoder2.Decode

let rec calcValue packet =
    match packet with
    | Number (_, value) -> value
    | Operator (_, op, sub) ->
        let subValues = sub |> List.map calcValue

        match op with
        | Sum -> subValues |> List.sum
        | Product -> subValues |> List.mult
        | Min -> subValues |> List.min
        | Max -> subValues |> List.max
        | GreaterThan -> if subValues.[0] > subValues.[1] then 1L else 0L
        | LessThan -> if subValues.[0] < subValues.[1] then 1L else 0L
        | EqualTo -> if subValues.[0] = subValues.[1] then 1L else 0L
