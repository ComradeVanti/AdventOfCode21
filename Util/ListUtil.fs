[<RequireQualifiedAccess>]
module AdventOfCode21.List

let countWith f list = list |> List.filter f |> List.length
