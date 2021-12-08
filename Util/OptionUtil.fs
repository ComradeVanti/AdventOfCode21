[<RequireQualifiedAccess>]
module AdventOfCode21.Option

let collect options =

    let rec collectUntilDone options =
        match options with
        | [] -> Some []
        | head :: tail ->
            match head, collectUntilDone tail with
            | Some item, Some items -> Some(item :: items)
            | _ -> None

    options |> Seq.toList |> collectUntilDone

let asResult noneError opt =
    match opt with
    | Some item -> Ok item
    | None -> Error noneError
