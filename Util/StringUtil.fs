[<RequireQualifiedAccess>]
module AdventOfCode21.String

open System

let splitAt (c: char) (s: string) =
    s.Split(c, StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

let splitCSV s = s |> splitAt ','

let isLower (s: string) = s |> Seq.forall Char.IsLower
