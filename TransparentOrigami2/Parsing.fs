module AdventOfCode21.TransparentOrigami2.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing
open AdventOfCode21.Vector
open AdventOfCode21.TransparentOrigami2.Paper

let tryParseInput lines =
    let dotLines, foldLines = lines |> List.splitAtItem ""

    let tryParseDot line : Dot option =
        line
        |> String.splitAt ','
        |> List.tryToTuple
        |> Option.bind (mapBoth tryParseInt >> Option.collectTuple)
        |> Option.map XY

    let tryParseFold line : Fold option =
        opt {
            let! axis =
                if line |> String.contains 'x' then Some Vertical
                elif line |> String.contains 'y' then Some Horizontal
                else None

            let! distance = line |> String.readAfter '=' |> tryParseInt
            return axis, distance
        }

    (dotLines
     |> List.map tryParseDot
     |> Option.collect
     |> Option.map makePaper,
     foldLines |> List.map tryParseFold |> Option.collect)
    |> Option.collectTuple
