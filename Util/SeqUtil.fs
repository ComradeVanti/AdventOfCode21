[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module AdventOfCode21.Seq

let allInRect w h =
    seq {
        for x in [ 0 .. w - 1 ] do
            for y in [ 0 .. h - 1 ] do
                yield (x, y)
    }
