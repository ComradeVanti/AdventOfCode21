module AdventOfCode21.ExtendedPolymerization1.Parsing

open AdventOfCode21.ExtendedPolymerization1.Polymer
open AdventOfCode21

let tryParseInput lines =

    let templateLine = lines |> List.head
    let ruleLines = lines |> List.skip 2

    let parseTemplate line = line |> Seq.toList |> Elements

    let tryParseRule line =
        opt {
            let! a = line |> String.tryGet 0
            let! b = line |> String.tryGet 1
            let! res = line |> String.tryGet 6

            return { A = a; B = b; Res = res }
        }

    opt {
        let template = templateLine |> parseTemplate
        let! rules = ruleLines |> List.map tryParseRule |> Option.collect
        return template, rules
    }
