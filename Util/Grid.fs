namespace AdventOfCode21

open AdventOfCode21.Vector

type Row<'Item> = Cells of 'Item list

type Grid<'Item> = Rows of Row<'Item> list

type CellPos = Vector

[<RequireQualifiedAccess>]
module Grid =

    let tryMake rows =

        let rowsAreEqualLength =
            rows |> List.map List.length |> List.distinct |> List.length = 1

        if rowsAreEqualLength then
            rows |> List.map Cells |> Rows |> Some
        else
            None

    let private rows (Rows rows) = rows

    let private cellsInRow (Cells cells) = cells

    let tryGet (XY (x, y): CellPos) grid =
        grid
        |> rows
        |> List.tryItem y
        |> Option.map cellsInRow
        |> Option.bind (List.tryItem x)

    let getAdjacentTo (XY (x, y): CellPos) grid =
        [ grid |> tryGet (XY(x - 1, y))
          grid |> tryGet (XY(x + 1, y))
          grid |> tryGet (XY(x, y - 1))
          grid |> tryGet (XY(x, y + 1)) ]
        |> List.choose id


    let cells (Rows rows) : (_ * CellPos) list =
        rows
        |> List.mapi
            (fun y (Cells cells) ->
                cells
                |> List.indexed
                |> List.map (fun (x, cell) -> cell, (XY(x, y))))
        |> List.concat

    let filter f grid = grid |> cells |> List.filter f
