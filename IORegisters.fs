﻿module IORegisters

open MemoryCell

// IORegister = Memory register
[<AbstractClass>]
type IORegister () as this =
    abstract MemoryValue: uint8 with get, set
    member val MemoryCell = VirtualCell((fun () -> this.MemoryValue), (fun newValue -> this.MemoryValue <- newValue))

// A memory register that is fundamentally a regular byte value
type ValueBackedIORegister(init) =
    inherit IORegister ()

    // We seperate the concept of register value and memory value
    // as writes for example may be disabled from memory, but enabled overall for the register.
    member val Value = init with get, set

    override this.MemoryValue
        with get () = this.Value
        and set newValue = this.Value <- newValue 



    