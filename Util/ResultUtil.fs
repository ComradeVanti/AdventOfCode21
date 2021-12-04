[<RequireQualifiedAccess>]
module AdventOfCode21.Result

let bindOption f noneError =
    Result.bind (
        f
        >> function
            | Some value -> Ok value
            | None -> Error noneError
    )
