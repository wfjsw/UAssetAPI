﻿namespace UAssetAPI.Kismet.Bytecode.Expressions
{
    /// <summary>
    /// A single Kismet bytecode instruction, corresponding to the <see cref="EExprToken.EX_ObjToInterfaceCast"/> instruction.
    /// A conversion from an object or interface variable to a native interface variable.
    /// </summary>
    public class EX_ObjToInterfaceCast : KismetExpression
    {
        /// <summary>
        /// The token of this expression.
        /// </summary>
        public override EExprToken Token { get { return EExprToken.EX_ObjToInterfaceCast; } }

        /// <summary>
        /// A pointer to the interface class to convert to.
        /// </summary>
        public ulong ClassPtr;

        /// <summary>
        /// The target of this expression.
        /// </summary>
        public KismetExpression Target;

        public EX_ObjToInterfaceCast()
        {

        }

        /// <summary>
        /// Reads out the expression from a BinaryReader.
        /// </summary>
        /// <param name="reader">The BinaryReader to read from.</param>
        public override void Read(AssetBinaryReader reader)
        {
            ClassPtr = reader.XFER_OBJECT_POINTER();
            Target = ExpressionSerializer.ReadExpression(reader);
        }

        /// <summary>
        /// Writes the expression to a BinaryWriter.
        /// </summary>
        /// <param name="writer">The BinaryWriter to write from.</param>
        /// <returns>The length in bytes of the data that was written.</returns>
        public override int Write(AssetBinaryWriter writer)
        {
            writer.XFER_OBJECT_POINTER(ClassPtr);
            ExpressionSerializer.WriteExpression(Target, writer);
            return 0;
        }
    }
}
