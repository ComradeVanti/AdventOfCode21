module AdventOfCode21.PassagePathing2.Parsing

open AdventOfCode21
open AdventOfCode21.PassagePathing2.CaveSystem
open Microsoft.FSharp.Collections

let tryParseInput lines : CaveSystem option =

    let tryMakePath parts =
        opt {
            let! fromCave = parts |> List.tryItem 0
            let! toCave = parts |> List.tryItem 1
            return { From = fromCave; To = toCave }
        }

    let tryParsePath line = line |> String.splitAt '-' |> tryMakePath

    let parseCave s =
        { Name = s
          Size = if s |> String.isLower then Small else Large }

    let addPath system path =
        { system with
              Caves =
                  system.Caves
                  |> Set.add (parseCave path.From)
                  |> Set.add (parseCave path.To)
              Paths = system.Paths |> Set.add path }

    let makeSystem paths = paths |> List.fold addPath emptySystem

    lines
    |> List.map tryParsePath
    |> Option.collect
    |> Option.map makeSystem
