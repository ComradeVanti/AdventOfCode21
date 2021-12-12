[<Microsoft.FSharp.Core.RequireQualifiedAccess>]
module ComradeVanti.AC21.SonarSweep1.Result

let ofOption noneError opt =
    match opt with
    | Some v -> Ok v
    | None -> Error noneError

let ofOp exnToError op =
    try
        op () |> Ok
    with
    | e -> e |> exnToError |> Error
