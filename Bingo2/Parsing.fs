module AdventOfCode21.Bingo2.Parsing

open System
open AdventOfCode21.Bingo2.Util
open AdventOfCode21.Bingo2.Bingo

let private splitAt (c: char) (line: string) =
    line.Split(c, StringSplitOptions.RemoveEmptyEntries)
    |> Array.toList

let private splitAtSpace line = line |> splitAt ' '

let private parseBoard lines =

    let parseRow line = line |> splitAtSpace |> List.map int

    lines |> List.map parseRow |> makeBoard

let parseGame lines =

    let boardLines = lines |> List.skip 2 |> splitAtItem ""

    boardLines |> List.map parseBoard |> startGame

let parseInputNumbers lines = lines |> List.head |> splitAt ',' |> List.map int
