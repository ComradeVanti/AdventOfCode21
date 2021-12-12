[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode21.Set

let trySingle set = set |> Set.toSeq |> Seq.tryHead

let tryFind pred set = set |> Set.filter pred |> trySingle
