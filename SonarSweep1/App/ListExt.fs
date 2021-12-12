[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module ComradeVanti.AC21.SonarSweep1.List

let countWhere pred = List.filter pred >> List.length

let ofTuple (a, b) = [ a; b ]
