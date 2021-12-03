[<AutoOpen>]
module AdventOfCode21.BinaryDiagnostic2.DomainTypes

type BinDigit =
    | I
    | O

type BinNum = BinDigit list
