module AdventOfCode21.DumboOctopus1.Parsing

open AdventOfCode21
open AdventOfCode21.Parsing
open AdventOfCode21.DumboOctopus1.Octopus


let tryParseInput lines =

    let tryParseOctopus c = c |> string |> tryParseInt |> Option.map makeOctopus

    let tryParseRow line = line |> Seq.map tryParseOctopus |> Option.collect

    lines
    |> List.map tryParseRow
    |> Option.collect
    |> Option.bind Grid.tryMake
