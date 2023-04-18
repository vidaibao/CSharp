using System;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;

namespace acad0open
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a new dwg file
            Database acCurDb = new Database(false, true);
            acCurDb.SaveAs("C:\\test.dwg", DwgVersion.Current);

            // Start a transaction
            using (Transaction acTrans = acCurDb.TransactionManager.StartTransaction())
            {
                // Open the Block table for read
                BlockTable acBlkTbl;
                acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId,
                                         OpenMode.ForRead) as BlockTable;

                // Open the Block table record Model space for write
                BlockTableRecord acBlkTblRec;
                acBlkTblRec = acTrans.GetObject(acBlkTbl[BlockTableRecord.ModelSpace],
                                            OpenMode.ForWrite) as BlockTableRecord;

                // Create a new circle object
                Circle acCirc = new Circle();
                acCirc.Radius = 5;
                acCirc.Center = new Point3d(5, 5, 0);

                // Add the new object to the block table record and the transaction
                acBlkTblRec.AppendEntity(acCirc);
                acTrans.AddNewlyCreatedDBObject(acCirc, true);

                // Save the new object to the database
                acTrans.Commit();
            }
            // open the dwg file
            Application.DocumentManager.Open(acCurDb, "test.dwg");
        }
    }
}

