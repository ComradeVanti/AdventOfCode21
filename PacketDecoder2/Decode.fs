module AdventOfCode21.PacketDecoder2.Decode

open AdventOfCode21.PacketDecoder2.Bin
open AdventOfCode21

type Version = int

type Op =
    | Sum
    | Product
    | Min
    | Max
    | GreaterThan
    | LessThan
    | EqualTo

type Packet =
    | Number of Version * int64
    | Operator of Version * Op * Packet list

type LengthMode =
    | Length
    | Count

type Context = | NewPacket


let tryDecodeNext i parser bits =
    if i <= (bits |> List.length) then
        bits |> List.splitAt i |> mapFst parser |> Some
    else
        None

let tryDecodeNextSingle parser bits =
    bits
    |> tryDecodeNext 1 id
    |> Option.map (mapFst (List.head >> parser))

let tryDecode (BitSequence bits) =

    let rec decodePacket bits =

        let decodeHeader bits =
            opt {
                let! version, bits = bits |> tryDecodeNext 3 (toDec >> int)
                let! typeId, bits = bits |> tryDecodeNext 3 (toDec >> int)
                return (version, typeId), bits
            }

        let decodeLiteral bits =

            let decodeBlock bits =
                opt {
                    let! isLast, bits = bits |> tryDecodeNextSingle ((=) Bit.O)

                    let! numBits, bits = bits |> tryDecodeNext 4 id
                    return (numBits, isLast), bits
                }

            let rec decodeUntilDone bits =
                opt {
                    let! (block, isLast), bits = bits |> decodeBlock

                    if isLast then
                        return block, bits
                    else
                        let! next, bits = bits |> decodeUntilDone
                        return block @ next, bits
                }

            bits |> decodeUntilDone |> Option.map (mapFst toDec)

        let decodeSubPackets bits =

            let rec decodeSubPacketsOfLength length bits =
                opt {
                    let! sub, nextBits = bits |> decodePacket

                    let packetLength =
                        (bits |> List.length) - (nextBits |> List.length)

                    let remaining = length - packetLength

                    if remaining = 0 then
                        return [ sub ], nextBits
                    else
                        let! next, bits =
                            nextBits |> decodeSubPacketsOfLength remaining

                        return (sub :: next), bits
                }

            let rec decodeSubPacketsOfCount count bits =
                opt {
                    if count = 0 then
                        return [], bits
                    else
                        let! sub, bits = bits |> decodePacket

                        let! next, bits =
                            bits |> decodeSubPacketsOfCount (count - 1)

                        return (sub :: next), bits
                }

            let tryParseLengthType bits =
                bits
                |> tryDecodeNextSingle
                    (fun m -> if m = Bit.O then Length else Count)

            let tryParseLength bits = bits |> tryDecodeNext 15 (toDec >> int)

            let tryParseCount bits = bits |> tryDecodeNext 11 (toDec >> int)

            opt {
                let! mode, bits = bits |> tryParseLengthType

                match mode with
                | Length ->
                    let! length, bits = bits |> tryParseLength
                    return! bits |> decodeSubPacketsOfLength length
                | Count ->
                    let! count, bits = bits |> tryParseCount
                    return! bits |> decodeSubPacketsOfCount count
            }

        opt {
            let! (version, typeId), bits = bits |> decodeHeader

            if typeId = 4 then
                let! num, bits = bits |> decodeLiteral
                return Number(version, num), bits
            else
                let! sub, bits = bits |> decodeSubPackets

                let! op =
                    if typeId = 0 then Some Sum
                    elif typeId = 1 then Some Product
                    elif typeId = 2 then Some Min
                    elif typeId = 3 then Some Max
                    elif typeId = 5 then Some GreaterThan
                    elif typeId = 6 then Some LessThan
                    elif typeId = 7 then Some EqualTo
                    else None

                return Operator(version, op, sub), bits
        }

    bits |> decodePacket |> Option.map fst
