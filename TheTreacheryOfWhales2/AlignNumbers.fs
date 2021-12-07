module AdventOfCode21.TheTreacheryOfWhales2.AlignNumbers


let private dist a b = abs (a - b)

let rec private triangleNum n = if n = 0L then n else n + (triangleNum (n - 1L))

let private costTo goal start = (dist goal start) |> triangleNum

let private calcCostFor alignNum numbers =
    numbers |> Seq.map (costTo alignNum) |> Seq.sum

let findMinimalAlignCost numbers : int64 =

    let positions =
        seq {
            let min = numbers |> Seq.min
            let max = numbers |> Seq.max

            yield! [ min .. max ]
        }

    positions
    |> Seq.distinct
    |> Seq.map (fun pos -> numbers |> calcCostFor pos)
    |> Seq.min
