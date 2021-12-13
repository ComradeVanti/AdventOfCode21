[<RequireQualifiedAccess>]
module AdventOfCode21.String

open System

let splitAt (c: char) (s: string) =
    s.Split(c, StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

let splitCSV s = s |> splitAt ','

let isLower (s: string) = s |> Seq.forall Char.IsLower

let readAfter (c: char) (s: string) =
    let i = s.IndexOf c

    if i = -1 then "" else s.Substring(i + 1)

let contains (c: char) (s: string) = s.Contains c
