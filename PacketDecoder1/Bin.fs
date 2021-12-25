module AdventOfCode21.PacketDecoder1.Bin

open AdventOfCode21.Binary


type Bit =
    | I = 1
    | O = 0

type Message = BitSequence of Bit list

let private toBinNum (bits: Bit list) = bits |> List.map int

let toDec bits = bits |> toBinNum |> binToDec
