# CMO v1.10 deobfuscation pipeline — inputs

- `bin/Command.exe`, `bin/CommandHost.exe` — original protected binaries (Build 1900.20).
- `bin/Command_unflat.exe` — rebuilt + unflattened Command.exe (input to NETReactorSlayer).
- `captures/run*` — profiler_v2 JIT captures (`jit_ftn.jsonl` + `jit_il.jsonl`), `run4/consts.json`
  (opaque constants), `run7|run8/strings.json` (decrypted strings). run3 has no locals info; run9 is a
  scenario run, run10/run11 are ForceJIT4/ForceJIT5 (generic instantiations).

Rebuild (tools in the repo, `tools/clr-profiler/`):

```
dotnet rebuild/bin/rebuild.dll bin/Command.exe Command.exe out/Command_unflat.exe \
    captures/run2 captures/run3 captures/run4 captures/run6 captures/run7 captures/run8 \
    captures/run9_scenario captures/run10_fj4 captures/run11_fj5
# → coverage report out/uncaptured.txt; then on the VM:
#   NETReactorSlayer-x64.CLI.exe Command_unflat.exe --dec-methods false --dec-rsrc false --preserve-all true --keep-max-stack true
dotnet decompile/bin/decompile.dll Command_unflat_Slayed.exe Command_src --ref <game dir DLLs>
```

CommandHost.exe has NOT been captured yet (40 450 encrypted bodies).
