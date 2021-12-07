module AdventOfCode21.TheTreacheryOfWhales1.AlignNumbers



let private costTo a b = abs (a - b)

let private calcCostFor alignNum numbers =
    numbers |> Seq.map (costTo alignNum) |> Seq.sum

let findMinimalAlignCost numbers =
    numbers
    |> Seq.map (fun align -> numbers |> calcCostFor align)
    |> Seq.min
