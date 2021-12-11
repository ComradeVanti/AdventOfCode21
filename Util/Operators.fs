[<Microsoft.FSharp.Core.AutoOpen>]
module AdventOfCode21.Operators

let (?||) pred trueMap falseMap v = if pred v then trueMap v else falseMap v
