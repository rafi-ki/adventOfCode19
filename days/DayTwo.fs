module DayTwo

let rec updateIntcode (array: int[]) index =
    let getOpFun i =
        let add x y = x + y
        let times x y = x * y
        let opcode = array.[i]
        match opcode with
                    | 1 -> Some add
                    | 2 -> Some times
                    | 99 -> None
    let i1 = index + 1
    let i2 = index + 2
    let update f = Array.set array array.[(index + 3)] (f array.[array.[i1]] array.[array.[i2]])
    match getOpFun index with
                        | Some f -> update f
                                    updateIntcode array (index + 4)
                        | None -> array

let partOne =
    printfn "day 2"
    let readFile() = System.IO.File.ReadAllText "input/day2.txt"
    let split (text:string) = text.Split [|','|]
    let inputList = readFile >> split >> Array.map int
    let inputListResult = inputList()
    let newArray = updateIntcode inputListResult 0
    newArray.[0] |> string