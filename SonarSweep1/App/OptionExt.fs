[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module ComradeVanti.AC21.SonarSweep1.Option

let collect options =

    let rec collectUntilDone options =
        match options with
        | [] -> Some []
        | head :: tail ->
            match head, collectUntilDone tail with
            | Some item, Some items -> Some(item :: items)
            | _ -> None

    options |> Seq.toList |> collectUntilDone

let ofOp op =
    try
        op () |> Some
    with
    | _ -> None
