﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 15.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.StreamProcessing
{
    using System.Linq;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    internal partial class ShuffleTemplate : CommonPipeTemplate
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"// *********************************************************************
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License
// *********************************************************************
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Microsoft.StreamProcessing;
using Microsoft.StreamProcessing.Internal;
using Microsoft.StreamProcessing.Internal.Collections;
[assembly: IgnoresAccessChecksTo(""Microsoft.StreamProcessing"")]

");

    var outputKey = !isFirstLevelGroup ? "CompoundGroupKey<" + TOuterKey + ", " + TInnerKey + ">" : TInnerKey;
    var nestedInfix = !isFirstLevelGroup ? "Nested" : (transformedKeySelectorAsString == string.Empty ? "SameKey" : string.Empty);

            this.Write("\r\n// Shuffle Pipe\r\n// TOuterKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKey));
            this.Write("\r\n// TInnerKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write("\r\n// TSource: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("\r\n// outputKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write("\r\n\r\n[DataContract]\r\ninternal sealed class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write(this.ToStringHelper.ToStringWithCulture(genericParameters));
            this.Write(" :\r\n                       Pipe<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(">,\r\n                       IStreamObserverAnd");
            this.Write(this.ToStringHelper.ToStringWithCulture(nestedInfix));
            this.Write("GroupedStreamObservable<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(">\r\n\r\n{\r\n\r\n");
  if (innerKeyIsAnonymous)
    { 
            this.Write("    [SchemaSerialization]\r\n    private readonly Expression<Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(", int>> keyComparer;\r\n    private readonly Func<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(", int> innerHashCode;\r\n");
  } 
            this.Write("\r\n    private readonly int totalBranchesL2, shuffleId, totalBranchesL2Mask;\r\n\r\n  " +
                    "  private readonly MemoryPool<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> l1Pool;\r\n\r\n    private List<IStreamObserver<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(">> Observers;\r\n    private readonly Func<PlanNode, IQueryObject, PlanNode> queryP" +
                    "lanGenerator;\r\n\r\n    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write("[] batches;\r\n\r\n    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(staticCtor));
            this.Write("\r\n\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("() { }\r\n\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("(\r\n        IStreamable<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> stream,\r\n        IStreamObserver<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> observer,\r\n        int _totalBranchesL2,\r\n        int _shuffleId,\r\n        Func" +
                    "<PlanNode, IQueryObject, PlanNode> queryPlanGenerator)\r\n        : base(stream, o" +
                    "bserver)\r\n    {\r\n");
  if (innerKeyIsAnonymous)
    {
        if (isFirstLevelGroup)
        { 
            this.Write("        keyComparer = stream.Properties.KeyEqualityComparer.GetGetHashCodeExpr();" +
                    "\r\n");
      }
        else
        { 
            this.Write("        keyComparer = ((CompoundGroupKeyEqualityComparer<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TInnerKey));
            this.Write(">)stream.Properties.KeyEqualityComparer).innerComparer.GetGetHashCodeExpr();\r\n");
      } 
            this.Write("        innerHashCode = keyComparer.Compile();\r\n");
  } 
            this.Write("        totalBranchesL2 = _totalBranchesL2;\r\n        totalBranchesL2Mask = totalB" +
                    "ranchesL2 - 1;\r\n        shuffleId = _shuffleId;\r\n        this.queryPlanGenerator" +
                    " = queryPlanGenerator;\r\n\r\n        l1Pool = MemoryManager.GetMemoryPool<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(">(true /*stream.Properties.IsColumnar*/);\r\n\r\n        Observers = new List<IStream" +
                    "Observer<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(">>();\r\n\r\n        batches = new ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write("[totalBranchesL2];\r\n    }\r\n\r\n    protected override void FlushContents()\r\n    {\r\n" +
                    "        StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(@"> batch;
        for (int i = 0; i < batches.Length; i++)
        {
            if (batches[0] == null || batches[i].Count == 0) continue;
            batches[i].Seal();
            Observers[i].OnNext(batches[i]);
            l1Pool.Get(out batch);
            batch.Allocate();
            var generatedBatch = batch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write(";\r\n");
  foreach (var f in this.fields.Where(fld => fld.OptimizeString()))
    { 
            this.Write("            generatedBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".Initialize();\r\n");
  } 
            this.Write(@"            batches[i] = generatedBatch;
        }
    }

    public override int CurrentlyBufferedOutputCount => 0;

    public override int CurrentlyBufferedInputCount => 0;

    public override void ProduceQueryPlan(PlanNode previous)
    {
        var node = queryPlanGenerator(previous, this);
        Observers.ForEach(o => o.ProduceQueryPlan(node));
    }

    public void AddObserver(IStreamObserver<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write(@"> observer)
    {
        Observers.Add(observer);
    }

    public override void OnFlush()
    {
        FlushContents();
        for (int j = 0; j < this.totalBranchesL2; j++)
        {
            this.Observers[j].OnFlush();
        }
    }

    public override void OnCompleted()
    {
        for (int j = 0; j < this.totalBranchesL2; j++)
        {
            this.batches[j].Free();
            this.Observers[j].OnCompleted();
        }
    }

    public override void OnError(Exception exception)
    {
        for (int j = 0; j < this.totalBranchesL2; j++)
        {
            this.batches[j].Free();
            this.Observers[j].OnError(exception);
        }
    }

    public unsafe void OnNext(StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> batch)\r\n    {\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKeyTSourceGenericParameters));
            this.Write(" sourceBatch = batch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(TOuterKeyTSourceGenericParameters));
            this.Write(";\r\n\r\n        var count = batch.Count;\r\n        var srckey = batch.key.col;\r\n\r\n");
  foreach (var f in this.fields)
    {
        if (f.canBeFixed)
        { 
            this.Write("        fixed (");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.TypeName));
            this.Write("* ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = sourceBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col)\r\n        {\r\n");
      }
        else if (f.OptimizeString())
        { 
            this.Write("\r\n        var ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = sourceBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(";\r\n");
      }
        else
        { 
            this.Write("\r\n        var ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col = sourceBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col;\r\n");
      }
    } 
            this.Write("\r\n        if (batches[0] == null)\r\n            for (int i = 0; i < totalBranchesL" +
                    "2; i++)\r\n            {\r\n                StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> newBatch;\r\n                l1Pool.Get(out newBatch);\r\n                newBatch." +
                    "Allocate();\r\n                var generatedBatch = newBatch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write(";\r\n");
  foreach (var f in this.fields.Where(fld => fld.OptimizeString()))
    { 
            this.Write("                generatedBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".Initialize(");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col.col.UsedLength);\r\n");
  } 
            this.Write("                batches[i] = generatedBatch;\r\n            }\r\n\r\n        ");
            this.Write(this.ToStringHelper.ToStringWithCulture(vectorHashCodeInitialization));
            this.Write("\r\n\r\n");

    string innerHash = (transformedKeySelectorAsString == string.Empty ? "src_hash[i]" : (innerKeyIsAnonymous ? "innerHashCode(key)" : inlinedHashCodeComputation));
    string index = isFirstLevelGroup ?
        (powerOf2 ? ("innerHash & totalBranchesL2Mask") : ("(innerHash & 0x7fffffff) % totalBranchesL2")) :
        (powerOf2? ("hash & totalBranchesL2Mask") : ("(hash & 0x7fffffff) % totalBranchesL2"));

            this.Write(@"
        fixed (long* src_bv = batch.bitvector.col)
        fixed (long* src_vsync = batch.vsync.col)
        fixed (long* src_vother = batch.vother.col)
        fixed (int* src_hash = batch.hash.col)
        {
            for (int i = 0; i < count; i++)
            {
                if ((src_bv[i >> 6] & (1L << (i & 0x3f))) != 0)
                {
                    if (src_vother[i] < 0)
                    {
                        // Add the punctuation/low watermark to all batches in the array
                        for (int batchIndex = 0; batchIndex < totalBranchesL2; batchIndex++)
                        {
                            var bb = batches[batchIndex];
                            var cc = bb.Count;
                            bb.vsync.col[cc] = src_vsync[i];
                            bb.vother.col[cc] = src_vother[i];
");
  if (isFirstLevelGroup)
    { 
            this.Write("                            bb.key.col[cc] = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.transformedKeySelectorAsString != string.Empty ? this.transformedKeySelectorAsString : "srckey[i]"));
            this.Write(";\r\n                            bb.hash.col[cc] = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(innerHash));
            this.Write(";\r\n");
  }
    else
    { 
            this.Write("                            if (src_vother[i] == StreamEvent.PunctuationOtherTime" +
                    ")\r\n                            {\r\n");
      if (transformedKeySelectorAsString != string.Empty)
        { 
            this.Write("                                var key = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.transformedKeySelectorAsString));
            this.Write(";\r\n                                var hash = src_hash[i] ^ ");
            this.Write(this.ToStringHelper.ToStringWithCulture(innerHash));
            this.Write(";\r\n                                bb.key.col[cc].outerGroup = srckey[i];\r\n      " +
                    "                          bb.key.col[cc].innerGroup = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.transformedKeySelectorAsString));
            this.Write(";\r\n                                bb.key.col[cc].hashCode = hash;\r\n             " +
                    "                   bb.hash.col[cc] = hash;\r\n");
      }
        else
        { 
            this.Write("                                bb.key.col[cc] = srckey[i];\r\n                    " +
                    "            bb.hash.col[cc] = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(innerHash));
            this.Write(";\r\n");
      } 
            this.Write("                            }\r\n                            else\r\n                " +
                    "            {\r\n                                bb.key.col[cc] = default;\r\n      " +
                    "                          bb.hash.col[cc] = 0;\r\n                            }\r\n");
  }

    foreach (var f in this.fields)
    {
        if (f.OptimizeString())
        { 
            this.Write("                            bb.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".AddString(string.Empty);\r\n");
      }
        else
        { 
            this.Write("                            bb.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col[cc] = default;\r\n");
      }
    } 
            this.Write(@"                            bb.bitvector.col[cc >> 6] |= (1L << (cc & 0x3f));
                            bb.Count++;
                            if (cc == Config.DataBatchSize - 1)
                            {
                                // flush this batch
                                if (batches[batchIndex].Count > 0)
                                {
                                    batches[batchIndex].iter = shuffleId;
                                    batches[batchIndex].Seal();
                                    Observers[batchIndex].OnNext(batches[batchIndex]);
                                    StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> newBatch;\r\n                                    l1Pool.Get(out newBatch);\r\n     " +
                    "                               newBatch.Allocate();\r\n                           " +
                    "         var generatedBatch = newBatch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write(";\r\n");
  foreach (var f in this.fields.Where(fld => fld.OptimizeString()))
    { 
            this.Write("                                    generatedBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".Initialize(");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col.col.UsedLength);\r\n");
  } 
            this.Write(@"                                    batches[batchIndex] = generatedBatch;

                                }
                            }
                        }

                    }
                    continue;
                }
                else
                {
");
  if (transformedKeySelectorAsString != string.Empty)
    { 
            this.Write("                    var key = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(this.transformedKeySelectorAsString));
            this.Write(";\r\n");
  } 
            this.Write("                    var innerHash = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(innerHash));
            this.Write(";\r\n\r\n");
  if (!isFirstLevelGroup)
    { 
            this.Write("                    var hash = src_hash[i] ^ innerHash;\r\n");
  } 
            this.Write("                    var index = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(index));
            this.Write(";\r\n                    var b = batches[index];\r\n                    var x = b.Cou" +
                    "nt;\r\n\r\n                    b.vsync.col[x] = src_vsync[i];\r\n                    b" +
                    ".vother.col[x] = src_vother[i];\r\n\r\n");
  if (transformedKeySelectorAsString != string.Empty)
    {
        if (isFirstLevelGroup)
        { 
            this.Write("                    b.key.col[x] = key;\r\n                    b.hash.col[x] = inne" +
                    "rHash;\r\n");
      }
        else
        { 
            this.Write("                    b.key.col[x].outerGroup = srckey[i];\r\n                    b.k" +
                    "ey.col[x].innerGroup = key;\r\n                    b.key.col[x].hashCode = hash;\r\n" +
                    "                    b.hash.col[x] = hash;\r\n");
      }
    }
    else
    { 
            this.Write("                    b.key.col[x] = srckey[i];\r\n                    b.hash.col[x] " +
                    "= innerHash;\r\n");
  } 
            this.Write("\r\n");
  foreach (var f in this.fields)
    {
        if (f.OptimizeString())
        { 
            this.Write("                    b.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".AddString(");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col,i);\r\n");
      }
        else
        { 
            this.Write("                    b.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".col[x] = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col[i];\r\n");
      }
    } 
            this.Write(@"
                    b.Count++;

                    if (x == Config.DataBatchSize - 1)
                    {
                        // flush this batch
                        int j = index;
                        //for (int j = 0; j < Config.ReduceArity; j++)
                        {
                            if (batches[j].Count > 0)
                            {
                                batches[j].iter = shuffleId;
                                batches[j].Seal();
                                Observers[j].OnNext(batches[j]);
                                StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(outputKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TSource));
            this.Write("> newBatch;\r\n                                l1Pool.Get(out newBatch);\r\n         " +
                    "                       newBatch.Allocate();\r\n                                var" +
                    " generatedBatch = newBatch as ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchClassType));
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchGenericParameters));
            this.Write(";\r\n");
  foreach (var f in this.fields.Where(fld => fld.OptimizeString()))
    { 
            this.Write("                                generatedBatch.");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write(".Initialize(");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("_col.col.UsedLength);\r\n");
  } 
            this.Write(@"                                batches[j] = generatedBatch;
                            }
                        }
                    }
                }
            } // end for loop
        } // end fixed src_hash, src_vother, src_vsync, src_bv

");
  if (!String.IsNullOrWhiteSpace(vectorHashCodeInitialization))
    { 
            this.Write("        hashCodeVector.Return();\r\n");
  }

    foreach (var f in this.fields.Where(fld => fld.canBeFixed))
    { 
            this.Write("\r\n        } // end fixed ");
            this.Write(this.ToStringHelper.ToStringWithCulture(f.Name));
            this.Write("\r\n");
  } 
            this.Write("\r\n        batch.Release();\r\n        batch.Return();\r\n    }\r\n}");
            return this.GenerationEnvironment.ToString();
        }
    }
}
