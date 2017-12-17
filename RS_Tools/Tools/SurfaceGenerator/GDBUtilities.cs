using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.IO;

namespace RS_Tools.Tools.SurfaceGenerator
{
    class GDBUtilities
    {

        public static IFeatureDataset GetFeatureDataset(string featuredatasetpath)
        {
            string workspacepath = System.IO.Path.GetDirectoryName(featuredatasetpath);
            IWorkspace workspace = GDBUtilities.FileGdbWorkspaceFromPath(workspacepath);
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace;
            string datasetname = featuredatasetpath.Replace(workspacepath, string.Empty);
            datasetname = datasetname.Replace("\\", string.Empty);
            IFeatureDataset outputfeaturedataset = featureWorkspace.OpenFeatureDataset(datasetname);
            return outputfeaturedataset;
        }

        public static IFeatureDataset GetFeatureDataset(string featuredatasetpath, out IFeatureWorkspace featureWorkspace)
        {
            string workspacepath = System.IO.Path.GetDirectoryName(featuredatasetpath);
            IWorkspace workspace = GDBUtilities.FileGdbWorkspaceFromPath(workspacepath);
            featureWorkspace = (IFeatureWorkspace)workspace;
            string datasetname = featuredatasetpath.Replace(workspacepath, string.Empty);
            datasetname = datasetname.Replace("\\", string.Empty);
            IFeatureDataset outputfeaturedataset = featureWorkspace.OpenFeatureDataset(datasetname);
            return outputfeaturedataset;
        }

        public static IWorkspace FileGdbWorkspaceFromPath(String path)
        {
            try
            {
                Type factoryType = Type.GetTypeFromProgID(
                    "esriDataSourcesGDB.FileGDBWorkspaceFactory");
                IWorkspaceFactory workspaceFactory = (IWorkspaceFactory)Activator.CreateInstance
                    (factoryType);
                return workspaceFactory.OpenFromFile(path, 0);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return null;
        }

        public static List<string> GetFeatureClassList(IFeatureDataset featuredataset, esriGeometryType geometrytype)
        {
            List<string> featureclasses = new List<string>();

            IEnumDataset enumdataset = featuredataset.Subsets;
            enumdataset.Reset();
            IDataset dataset = enumdataset.Next();
            while (dataset != null)
            {
                if (dataset is IFeatureClass)
                {
                    IFeatureClass featureclass = dataset as IFeatureClass;
                    if (featureclass.ShapeType == geometrytype)
                        featureclasses.Add(featureclass.AliasName);
                }
                dataset = enumdataset.Next();
            }
            return featureclasses;
        }

        public static IFeatureClass GetFeatureClass(IFeatureDataset featuredataset, string strFeatureClassName)
        {
            IFeatureClass featureclass = null;
            try
            {
                IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featuredataset;
                featureclass = featureClassContainer.get_ClassByName(strFeatureClassName);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return featureclass;
        }

        public static IFeatureClass CreateFeatureClass(IWorkspace2 workspace, IFeatureDataset featureDataset, String featureClassName, IFields fields, String strConfigKeyword)
        {
            if (featureClassName == "") return null; // name was not passed in 

            IFeatureClass featureClass;
            IFeatureWorkspace featureWorkspace = (IFeatureWorkspace)workspace; // Explicit Cast

            if (workspace.get_NameExists(esriDatasetType.esriDTFeatureClass, featureClassName)) //feature class with that name already exists 
            {
                featureClass = featureWorkspace.OpenFeatureClass(featureClassName);
                return featureClass;
            }

            // assign the class id value if not assigned
            UID uID = new UIDClass();
            uID.Value = "esriGeoDatabase.Feature";

            IObjectClassDescription objectClassDescription = new FeatureClassDescriptionClass();

            // if a fields collection is not passed in then supply our own
            if (fields == null)
            {
                // create the fields using the required fields method
                fields = objectClassDescription.RequiredFields;
                IFieldsEdit fieldsEdit = (IFieldsEdit)fields; // Explicit Cast
                IField field = new FieldClass();

                // create a user defined text field
                IFieldEdit fieldEdit = (IFieldEdit)field; // Explicit Cast

                // setup field properties
                fieldEdit.Name_2 = "SampleField";
                fieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
                fieldEdit.IsNullable_2 = true;
                fieldEdit.AliasName_2 = "Sample Field Column";
                fieldEdit.DefaultValue_2 = "test";
                fieldEdit.Editable_2 = true;
                fieldEdit.Length_2 = 100;

                // add field to field collection
                fieldsEdit.AddField(field);
                fields = (IFields)fieldsEdit; // Explicit Cast
            }

            String strShapeField = "";

            // locate the shape field
            for (int j = 0; j < fields.FieldCount; j++)
            {
                if (fields.get_Field(j).Type == esriFieldType.esriFieldTypeGeometry)
                {
                    strShapeField = fields.get_Field(j).Name;
                }
            }

            // Use IFieldChecker to create a validated fields collection.
            IFieldChecker fieldChecker = new FieldCheckerClass();
            IEnumFieldError enumFieldError = null;
            IFields validatedFields = null;
            fieldChecker.ValidateWorkspace = (IWorkspace)workspace;
            fieldChecker.Validate(fields, out enumFieldError, out validatedFields);

            // The enumFieldError enumerator can be inspected at this point to determine 
            // which fields were modified during validation.


            // finally create and return the feature class
            if (featureDataset == null)// if no feature dataset passed in, create at the workspace level
            {
                featureClass = featureWorkspace.CreateFeatureClass(featureClassName, validatedFields, uID, null, esriFeatureType.esriFTSimple, strShapeField, strConfigKeyword);
            }
            else
            {
                featureClass = featureDataset.CreateFeatureClass(featureClassName, validatedFields, uID, null, esriFeatureType.esriFTSimple, strShapeField, strConfigKeyword);
            }
            return featureClass;
        }

        public static bool Delete(IFeatureDataset featuredataset, string strFeatureClassName)
        {
            bool success = false;
            try
            {

                IFeatureClass featureclass = GetFeatureClass(featuredataset, strFeatureClassName);

                if (featureclass != null)
                {
                    IDataset dataset = featureclass as IDataset;

                    dataset.Delete();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return success;
        }

        public static bool Rename(IFeatureClass featureclass, string strFeatureClassName)
        {
            bool success = false;
            try
            {

                if (featureclass != null)
                {
                    IDataset dataset = featureclass as IDataset;

                    if (dataset.CanRename())
                    {
                        dataset.Rename(strFeatureClassName);
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            return success;
        }

        public static IFields NewPointFields(ISpatialReference spatialreference)
        {
            IFields outputfields = new FieldsClass();
            IFieldsEdit outputfieldsedit = (IFieldsEdit)outputfields;

            //Create FID Field (0)
            IField fidfield = new FieldClass();
            IFieldEdit fidfieldedit = (IFieldEdit)fidfield;
            fidfieldedit.AliasName_2 = "FID";
            fidfieldedit.Name_2 = "ID";
            fidfieldedit.Type_2 = esriFieldType.esriFieldTypeOID;
            outputfieldsedit.AddField(fidfield);

            //Create shape field (1)
            IField shapefield = new FieldClass();
            IFieldEdit shapefieldedit = (IFieldEdit)shapefield;

            //Geometry definition
            IGeometryDef geometrydef = new GeometryDefClass();
            IGeometryDefEdit geometrydefedit = (IGeometryDefEdit)geometrydef;
            geometrydefedit.AvgNumPoints_2 = 5;
            geometrydefedit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            geometrydefedit.GridCount_2 = 1;
            geometrydefedit.set_GridSize(0, 200);
            geometrydefedit.HasM_2 = false;
            geometrydefedit.HasZ_2 = true;
            IClone clone = (IClone)spatialreference;
            ISpatialReference spatialreference2 = (ISpatialReference)clone;
            geometrydefedit.SpatialReference_2 = spatialreference2;
            shapefieldedit.Name_2 = "SHAPE";
            shapefieldedit.AliasName_2 = "SHAPE";
            shapefieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            shapefieldedit.GeometryDef_2 = geometrydef;
            shapefieldedit.IsNullable_2 = true;
            shapefieldedit.Required_2 = true;
            outputfieldsedit.AddField(shapefield);

            //Status field
            IField statusfield = new FieldClass();
            IFieldEdit2 statusfieldedit = (IFieldEdit2)statusfield;
            statusfieldedit.AliasName_2 = "Type";
            statusfieldedit.Name_2 = "Type;";
            statusfieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            statusfieldedit.Length_2 = 50;
            outputfieldsedit.AddField(statusfield);

            //Related contour FID
            IField contourfield = new FieldClass();
            IFieldEdit2 contourfieldedit = (IFieldEdit2)contourfield;
            contourfieldedit.AliasName_2 = "Contour";
            contourfieldedit.Name_2 = "Contour;";
            contourfieldedit.Type_2 = esriFieldType.esriFieldTypeInteger;
            outputfieldsedit.AddField(contourfield);

            //Contour elevation
            IField elevationfield = new FieldClass();
            IFieldEdit2 elevationfieldedit = (IFieldEdit2)elevationfield;
            elevationfieldedit.AliasName_2 = "Elevation";
            elevationfieldedit.Name_2 = "Elevation";
            elevationfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(elevationfield);

            return outputfields;
        }

        public static IFields NewLineFields(ISpatialReference spatialreference)
        {
            IFields outputfields = new FieldsClass();
            IFieldsEdit outputfieldsedit = (IFieldsEdit)outputfields;

            //Create FID Field (0)
            IField fidfield = new FieldClass();
            IFieldEdit fidfieldedit = (IFieldEdit)fidfield;
            fidfieldedit.AliasName_2 = "FID";
            fidfieldedit.Name_2 = "ID";
            fidfieldedit.Type_2 = esriFieldType.esriFieldTypeOID;
            outputfieldsedit.AddField(fidfield);

            //Create shape field (1)
            IField shapefield = new FieldClass();
            IFieldEdit shapefieldedit = (IFieldEdit)shapefield;

            //Geometry definition
            IGeometryDef geometrydef = new GeometryDefClass();
            IGeometryDefEdit geometrydefedit = (IGeometryDefEdit)geometrydef;
            geometrydefedit.AvgNumPoints_2 = 5;
            geometrydefedit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            geometrydefedit.GridCount_2 = 1;
            geometrydefedit.set_GridSize(0, 200);
            geometrydefedit.HasM_2 = false;
            geometrydefedit.HasZ_2 = false;
            IClone clone = (IClone)spatialreference;
            ISpatialReference spatialreference2 = (ISpatialReference)clone;
            geometrydefedit.SpatialReference_2 = spatialreference2;
            shapefieldedit.Name_2 = "SHAPE";
            shapefieldedit.AliasName_2 = "SHAPE";
            shapefieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            shapefieldedit.GeometryDef_2 = geometrydef;
            shapefieldedit.IsNullable_2 = true;
            shapefieldedit.Required_2 = true;
            outputfieldsedit.AddField(shapefield);

            //Grade field
            IField gradefield = new FieldClass();
            IFieldEdit gradefieldedit = (IFieldEdit)gradefield;
            gradefieldedit.AliasName_2 = "Grade";
            gradefieldedit.Name_2 = "Grade";
            gradefieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(gradefield);

            //Absolute Grade field
            IField absgradefield = new FieldClass();
            IFieldEdit absgradefieldedit = (IFieldEdit)absgradefield;
            absgradefieldedit.AliasName_2 = "AbsGrade";
            absgradefieldedit.Name_2 = "AbsGrade";
            absgradefieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(absgradefield);

            //NLFID field
            IField nlfidfield = new FieldClass();
            IFieldEdit nlfidfieldedit = (IFieldEdit)nlfidfield;
            nlfidfieldedit.AliasName_2 = "NLFID";
            nlfidfieldedit.Name_2 = "NLFID";
            nlfidfieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            nlfidfieldedit.Length_2 = 25;
            outputfieldsedit.AddField(nlfidfield);

            //Beg_log field
            IField beglogfield = new FieldClass();
            IFieldEdit beglogfieldedit = (IFieldEdit)beglogfield;
            beglogfieldedit.AliasName_2 = "BEG_LOG";
            beglogfieldedit.Name_2 = "BEG_LOG";
            beglogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(beglogfield);

            //End_log field
            IField endlogfield = new FieldClass();
            IFieldEdit endlogfieldedit = (IFieldEdit)endlogfield;
            endlogfieldedit.AliasName_2 = "END_LOG";
            endlogfieldedit.Name_2 = "END_LOG";
            endlogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(endlogfield);

            //Grade field
            IField seglegfield = new FieldClass();
            IFieldEdit seglegfieldedit = (IFieldEdit)seglegfield;
            seglegfieldedit.AliasName_2 = "LENGTH3D";
            seglegfieldedit.Name_2 = "LENGTH3D";
            seglegfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(seglegfield);

            return outputfields;
        }

        public static IFields NewLineFieldsC(ISpatialReference spatialreference)
        {
            IFields outputfields = new FieldsClass();
            IFieldsEdit outputfieldsedit = (IFieldsEdit)outputfields;

            //Create FID Field (0)
            IField fidfield = new FieldClass();
            IFieldEdit fidfieldedit = (IFieldEdit)fidfield;
            fidfieldedit.AliasName_2 = "FID";
            fidfieldedit.Name_2 = "ID";
            fidfieldedit.Type_2 = esriFieldType.esriFieldTypeOID;
            outputfieldsedit.AddField(fidfield);

            //Create shape field (1)
            IField shapefield = new FieldClass();
            IFieldEdit shapefieldedit = (IFieldEdit)shapefield;

            //Geometry definition
            IGeometryDef geometrydef = new GeometryDefClass();
            IGeometryDefEdit geometrydefedit = (IGeometryDefEdit)geometrydef;
            geometrydefedit.AvgNumPoints_2 = 5;
            geometrydefedit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            geometrydefedit.GridCount_2 = 1;
            geometrydefedit.set_GridSize(0, 200);
            geometrydefedit.HasM_2 = false;
            geometrydefedit.HasZ_2 = false;
            IClone clone = (IClone)spatialreference;
            ISpatialReference spatialreference2 = (ISpatialReference)clone;
            geometrydefedit.SpatialReference_2 = spatialreference2;
            shapefieldedit.Name_2 = "SHAPE";
            shapefieldedit.AliasName_2 = "SHAPE";
            shapefieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            shapefieldedit.GeometryDef_2 = geometrydef;
            shapefieldedit.IsNullable_2 = true;
            shapefieldedit.Required_2 = true;
            outputfieldsedit.AddField(shapefield);

            //Curve field
            IField curvefield = new FieldClass();
            IFieldEdit curvefieldedit = (IFieldEdit)curvefield;
            curvefieldedit.AliasName_2 = "Curve";
            curvefieldedit.Name_2 = "Curve";
            curvefieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(curvefield);

            //NLFID field
            IField nlfidfield = new FieldClass();
            IFieldEdit nlfidfieldedit = (IFieldEdit)nlfidfield;
            nlfidfieldedit.AliasName_2 = "NLFID";
            nlfidfieldedit.Name_2 = "NLFID";
            nlfidfieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            nlfidfieldedit.Length_2 = 25;
            outputfieldsedit.AddField(nlfidfield);

            //Beg_log field
            IField beglogfield = new FieldClass();
            IFieldEdit beglogfieldedit = (IFieldEdit)beglogfield;
            beglogfieldedit.AliasName_2 = "BEG_LOG";
            beglogfieldedit.Name_2 = "BEG_LOG";
            beglogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(beglogfield);

            //End_log field
            IField endlogfield = new FieldClass();
            IFieldEdit endlogfieldedit = (IFieldEdit)endlogfield;
            endlogfieldedit.AliasName_2 = "END_LOG";
            endlogfieldedit.Name_2 = "END_LOG";
            endlogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(endlogfield);

            //Grade field
            IField seglegfield = new FieldClass();
            IFieldEdit seglegfieldedit = (IFieldEdit)seglegfield;
            seglegfieldedit.AliasName_2 = "LENGTH3D";
            seglegfieldedit.Name_2 = "LENGTH3D";
            seglegfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(seglegfield);

            return outputfields;
        }

        public static IFields NewLineFieldsV(ISpatialReference spatialreference)
        {
            IFields outputfields = new FieldsClass();
            IFieldsEdit outputfieldsedit = (IFieldsEdit)outputfields;

            //Create FID Field (0)
            IField fidfield = new FieldClass();
            IFieldEdit fidfieldedit = (IFieldEdit)fidfield;
            fidfieldedit.AliasName_2 = "FID";
            fidfieldedit.Name_2 = "ID";
            fidfieldedit.Type_2 = esriFieldType.esriFieldTypeOID;
            outputfieldsedit.AddField(fidfield);

            //Create shape field (1)
            IField shapefield = new FieldClass();
            IFieldEdit shapefieldedit = (IFieldEdit)shapefield;

            //Geometry definition
            IGeometryDef geometrydef = new GeometryDefClass();
            IGeometryDefEdit geometrydefedit = (IGeometryDefEdit)geometrydef;
            geometrydefedit.AvgNumPoints_2 = 5;
            geometrydefedit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            geometrydefedit.GridCount_2 = 1;
            geometrydefedit.set_GridSize(0, 200);
            geometrydefedit.HasM_2 = false;
            geometrydefedit.HasZ_2 = false;
            IClone clone = (IClone)spatialreference;
            ISpatialReference spatialreference2 = (ISpatialReference)clone;
            geometrydefedit.SpatialReference_2 = spatialreference2;
            shapefieldedit.Name_2 = "SHAPE";
            shapefieldedit.AliasName_2 = "SHAPE";
            shapefieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            shapefieldedit.GeometryDef_2 = geometrydef;
            shapefieldedit.IsNullable_2 = true;
            shapefieldedit.Required_2 = true;
            outputfieldsedit.AddField(shapefield);

            //Grade field
            IField gradefield = new FieldClass();
            IFieldEdit gradefieldedit = (IFieldEdit)gradefield;
            gradefieldedit.AliasName_2 = "Grade";
            gradefieldedit.Name_2 = "Grade";
            gradefieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(gradefield);

            //Absolute Grade field
            IField absgradefield = new FieldClass();
            IFieldEdit absgradefieldedit = (IFieldEdit)absgradefield;
            absgradefieldedit.AliasName_2 = "AbsGrade";
            absgradefieldedit.Name_2 = "AbsGrade";
            absgradefieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(absgradefield);

            //NLFID field
            IField nlfidfield = new FieldClass();
            IFieldEdit nlfidfieldedit = (IFieldEdit)nlfidfield;
            nlfidfieldedit.AliasName_2 = "NLFID";
            nlfidfieldedit.Name_2 = "NLFID";
            nlfidfieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            nlfidfieldedit.Length_2 = 25;
            outputfieldsedit.AddField(nlfidfield);

            //Beg_log field
            IField beglogfield = new FieldClass();
            IFieldEdit beglogfieldedit = (IFieldEdit)beglogfield;
            beglogfieldedit.AliasName_2 = "BEG_LOG";
            beglogfieldedit.Name_2 = "BEG_LOG";
            beglogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(beglogfield);

            //End_log field
            IField endlogfield = new FieldClass();
            IFieldEdit endlogfieldedit = (IFieldEdit)endlogfield;
            endlogfieldedit.AliasName_2 = "END_LOG";
            endlogfieldedit.Name_2 = "END_LOG";
            endlogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(endlogfield);

            //Segment length field
            IField seglegfield = new FieldClass();
            IFieldEdit seglegfieldedit = (IFieldEdit)seglegfield;
            seglegfieldedit.AliasName_2 = "LENGTH3D";
            seglegfieldedit.Name_2 = "LENGTH3D";
            seglegfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(seglegfield);

            //Comment
            IField commentfield = new FieldClass();
            IFieldEdit commentfieldedit = (IFieldEdit)commentfield;
            commentfieldedit.AliasName_2 = "COMMENT";
            commentfieldedit.Name_2 = "COMMENT";
            commentfieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            commentfieldedit.Length_2 = 250;
            outputfieldsedit.AddField(commentfield);

            return outputfields;
        }

        public static IFields NewLineFieldsVC(ISpatialReference spatialreference)
        {
            IFields outputfields = new FieldsClass();
            IFieldsEdit outputfieldsedit = (IFieldsEdit)outputfields;

            //Create FID Field (0)
            IField fidfield = new FieldClass();
            IFieldEdit fidfieldedit = (IFieldEdit)fidfield;
            fidfieldedit.AliasName_2 = "FID";
            fidfieldedit.Name_2 = "ID";
            fidfieldedit.Type_2 = esriFieldType.esriFieldTypeOID;
            outputfieldsedit.AddField(fidfield);

            //Create shape field (1)
            IField shapefield = new FieldClass();
            IFieldEdit shapefieldedit = (IFieldEdit)shapefield;

            //Geometry definition
            IGeometryDef geometrydef = new GeometryDefClass();
            IGeometryDefEdit geometrydefedit = (IGeometryDefEdit)geometrydef;
            geometrydefedit.AvgNumPoints_2 = 5;
            geometrydefedit.GeometryType_2 = esriGeometryType.esriGeometryPolyline;
            geometrydefedit.GridCount_2 = 1;
            geometrydefedit.set_GridSize(0, 200);
            geometrydefedit.HasM_2 = false;
            geometrydefedit.HasZ_2 = false;
            IClone clone = (IClone)spatialreference;
            ISpatialReference spatialreference2 = (ISpatialReference)clone;
            geometrydefedit.SpatialReference_2 = spatialreference2;
            shapefieldedit.Name_2 = "SHAPE";
            shapefieldedit.AliasName_2 = "SHAPE";
            shapefieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            shapefieldedit.GeometryDef_2 = geometrydef;
            shapefieldedit.IsNullable_2 = true;
            shapefieldedit.Required_2 = true;
            outputfieldsedit.AddField(shapefield);

            //Curve field
            IField curvefield = new FieldClass();
            IFieldEdit curvefieldedit = (IFieldEdit)curvefield;
            curvefieldedit.AliasName_2 = "Curve";
            curvefieldedit.Name_2 = "Curve";
            curvefieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(curvefield);

            //NLFID field
            IField nlfidfield = new FieldClass();
            IFieldEdit nlfidfieldedit = (IFieldEdit)nlfidfield;
            nlfidfieldedit.AliasName_2 = "NLFID";
            nlfidfieldedit.Name_2 = "NLFID";
            nlfidfieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            nlfidfieldedit.Length_2 = 25;
            outputfieldsedit.AddField(nlfidfield);

            //Beg_log field
            IField beglogfield = new FieldClass();
            IFieldEdit beglogfieldedit = (IFieldEdit)beglogfield;
            beglogfieldedit.AliasName_2 = "BEG_LOG";
            beglogfieldedit.Name_2 = "BEG_LOG";
            beglogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(beglogfield);

            //End_log field
            IField endlogfield = new FieldClass();
            IFieldEdit endlogfieldedit = (IFieldEdit)endlogfield;
            endlogfieldedit.AliasName_2 = "END_LOG";
            endlogfieldedit.Name_2 = "END_LOG";
            endlogfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(endlogfield);

            //Segment length field
            IField seglegfield = new FieldClass();
            IFieldEdit seglegfieldedit = (IFieldEdit)seglegfield;
            seglegfieldedit.AliasName_2 = "LENGTH3D";
            seglegfieldedit.Name_2 = "LENGTH3D";
            seglegfieldedit.Type_2 = esriFieldType.esriFieldTypeDouble;
            outputfieldsedit.AddField(seglegfield);

            //Comment
            IField commentfield = new FieldClass();
            IFieldEdit commentfieldedit = (IFieldEdit)commentfield;
            commentfieldedit.AliasName_2 = "COMMENT";
            commentfieldedit.Name_2 = "COMMENT";
            commentfieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            commentfieldedit.Length_2 = 250;
            outputfieldsedit.AddField(commentfield);

            return outputfields;
        }

        public static IFields NewPolygonFields(ISpatialReference spatialreference)
        {
            IFields outputfields = new FieldsClass();
            IFieldsEdit outputfieldsedit = (IFieldsEdit)outputfields;

            //Create FID Field (0)
            IField fidfield = new FieldClass();
            IFieldEdit fidfieldedit = (IFieldEdit)fidfield;
            fidfieldedit.AliasName_2 = "FID";
            fidfieldedit.Name_2 = "ID";
            fidfieldedit.Type_2 = esriFieldType.esriFieldTypeOID;
            outputfieldsedit.AddField(fidfield);

            //Create shape field (1)
            IField shapefield = new FieldClass();
            IFieldEdit shapefieldedit = (IFieldEdit)shapefield;

            //Geometry definition
            IGeometryDef geometrydef = new GeometryDefClass();
            IGeometryDefEdit geometrydefedit = (IGeometryDefEdit)geometrydef;
            geometrydefedit.AvgNumPoints_2 = 5;
            geometrydefedit.GeometryType_2 = esriGeometryType.esriGeometryPolygon;
            geometrydefedit.GridCount_2 = 1;
            geometrydefedit.set_GridSize(0, 200);
            geometrydefedit.HasM_2 = false;
            geometrydefedit.HasZ_2 = false;
            IClone clone = (IClone)spatialreference;
            ISpatialReference spatialreference2 = (ISpatialReference)clone;
            geometrydefedit.SpatialReference_2 = spatialreference2;
            shapefieldedit.Name_2 = "SHAPE";
            shapefieldedit.AliasName_2 = "SHAPE";
            shapefieldedit.Type_2 = esriFieldType.esriFieldTypeGeometry;
            shapefieldedit.GeometryDef_2 = geometrydef;
            shapefieldedit.IsNullable_2 = true;
            shapefieldedit.Required_2 = true;
            outputfieldsedit.AddField(shapefield);

            //Building ID field
            IField buildingoidfield = new FieldClass();
            IFieldEdit buildingoidfieldedit = (IFieldEdit)buildingoidfield;
            buildingoidfieldedit.AliasName_2 = "BuildingOID";
            buildingoidfieldedit.Name_2 = "BuildingOID";
            buildingoidfieldedit.Type_2 = esriFieldType.esriFieldTypeInteger;
            outputfieldsedit.AddField(buildingoidfield);

            //Tile Index Name ID field
            IField tileindex1namefield = new FieldClass();
            IFieldEdit tileindex1namefieldedit = (IFieldEdit)tileindex1namefield;
            tileindex1namefieldedit.AliasName_2 = "TileIndex1";
            tileindex1namefieldedit.Name_2 = "TileIndex1";
            tileindex1namefieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            tileindex1namefieldedit.Length_2 = 25;
            outputfieldsedit.AddField(tileindex1namefield);

            //Tile Index Name ID field
            IField tileindex2namefield = new FieldClass();
            IFieldEdit tileindex2namefieldedit = (IFieldEdit)tileindex2namefield;
            tileindex2namefieldedit.AliasName_2 = "TileIndex2";
            tileindex2namefieldedit.Name_2 = "TileIndex2";
            tileindex2namefieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            tileindex2namefieldedit.Length_2 = 25;
            outputfieldsedit.AddField(tileindex2namefield);

            //Tile Index Name ID field
            IField tileindex3namefield = new FieldClass();
            IFieldEdit tileindex3namefieldedit = (IFieldEdit)tileindex3namefield;
            tileindex3namefieldedit.AliasName_2 = "TileIndex3";
            tileindex3namefieldedit.Name_2 = "TileIndex3";
            tileindex3namefieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            tileindex3namefieldedit.Length_2 = 25;
            outputfieldsedit.AddField(tileindex3namefield);

            //Tile Index Name ID field
            IField tileindex4namefield = new FieldClass();
            IFieldEdit tileindex4namefieldedit = (IFieldEdit)tileindex4namefield;
            tileindex4namefieldedit.AliasName_2 = "TileIndex4";
            tileindex4namefieldedit.Name_2 = "TileIndex4";
            tileindex4namefieldedit.Type_2 = esriFieldType.esriFieldTypeString;
            tileindex4namefieldedit.Length_2 = 25;
            outputfieldsedit.AddField(tileindex4namefield);

            return outputfields;
        }

        public static int FindField(object o, string FieldName)
        {
            try
            {
                if (o is ILayer)
                {
                    ILayer layer = (ILayer)o;
                    if (!(layer == null))
                    {
                        IFeatureLayer featurelayer = (IFeatureLayer)layer;
                        if (!(featurelayer == null))
                        {
                            int i = featurelayer.FeatureClass.Fields.FindField(FieldName);
                            if (i > -1)
                                return i;
                            else
                            {
                                for (int j = 0; j < featurelayer.FeatureClass.Fields.FieldCount; j++)
                                {
                                    if (FieldName.CompareTo(featurelayer.FeatureClass.Fields.get_Field(j).AliasName) == 0)
                                        return j;
                                }
                            }
                        }
                    }
                }
                if (o is IFeatureLayer)
                {
                    IFeatureLayer featurelayer = (IFeatureLayer)o;
                    if (!(featurelayer == null))
                    {
                        int i = featurelayer.FeatureClass.Fields.FindField(FieldName);
                        if (i > -1)
                            return i;
                        else
                        {
                            for (int j = 0; j < featurelayer.FeatureClass.Fields.FieldCount; j++)
                            {
                                if (FieldName.CompareTo(featurelayer.FeatureClass.Fields.get_Field(j).AliasName) == 0)
                                    return j;
                            }
                        }
                    }
                }
                if (o is IFeatureClass)
                {
                    IFeatureClass featureclass = (IFeatureClass)o;
                    if (!(featureclass == null))
                    {
                        int i = featureclass.Fields.FindField(FieldName);
                        if (i > -1)
                            return i;
                        else
                        {
                            for (int j = 0; j < featureclass.Fields.FieldCount; j++)
                            {
                                if (FieldName.CompareTo(featureclass.Fields.get_Field(j).AliasName) == 0)
                                    return j;
                            }
                        }
                    }
                }
                if (o is IFeature)
                {
                    IFeature feature = (IFeature)o;
                    if (!(feature == null))
                    {
                        int i = feature.Fields.FindField(FieldName);
                        if (i > -1)
                            return i;
                        else
                        {
                            for (int j = 0; j < feature.Fields.FieldCount; j++)
                            {
                                if (FieldName.CompareTo(feature.Fields.get_Field(j).AliasName) == 0)
                                    return j;
                            }
                        }
                    }
                }
                if (o is IRow)
                {
                    IRow row = (IRow)o;
                    if (!(row == null))
                    {
                        int i = row.Fields.FindField(FieldName);
                        if (i > -1)
                            return i;
                        else
                        {
                            for (int j = 0; j < row.Fields.FieldCount; j++)
                            {
                                if (FieldName.CompareTo(row.Fields.get_Field(j).AliasName) == 0)
                                    return j;
                            }
                        }
                    }
                }
                if (o is ITable)
                {
                    ITable table = (ITable)o;
                    if (!(table == null))
                    {
                        int i = table.FindField(FieldName);
                        if (i > -1)
                            return i;
                        else
                        {
                            for (int j = 0; j < table.Fields.FieldCount; j++)
                            {
                                if (FieldName.CompareTo(table.Fields.get_Field(j).AliasName) == 0)
                                    return j;
                            }
                        }
                    }
                }
                if (o is IStandaloneTable)
                {
                    IStandaloneTable standalonetable = (IStandaloneTable)o;
                    int i = standalonetable.Table.FindField(FieldName);
                    if (i > -1)
                        return i;
                    else
                    {
                        for (int j = 0; j < standalonetable.Table.Fields.FieldCount; j++)
                        {
                            if (FieldName.CompareTo(standalonetable.Table.Fields.get_Field(j).AliasName) == 0)
                                return j;
                        }
                    }
                }
                if (o is ITableFields)
                {
                    ITableFields tablefields = (ITableFields)o;
                    int i = tablefields.FindField(FieldName);
                    if (i > -1)
                        return i;
                    else
                    {
                        for (int j = 0; j < tablefields.FieldCount; j++)
                        {
                            if (FieldName.CompareTo(tablefields.get_FieldInfo(j).Alias) == 0)
                                return j;
                        }
                    }
                }
                if (o is IGeoFeatureLayer)
                {
                    IGeoFeatureLayer geofeaturelayer = (IGeoFeatureLayer)o;
                    if (!(geofeaturelayer == null))
                    {
                        IFeatureLayer featurelayer = (IFeatureLayer)geofeaturelayer;
                        if (!(featurelayer == null))
                        {
                            int i = featurelayer.FeatureClass.Fields.FindField(FieldName);
                            if (i > -1)
                                return i;
                            else
                            {
                                for (int j = 0; j < featurelayer.FeatureClass.Fields.FieldCount; j++)
                                {
                                    if (FieldName.CompareTo(featurelayer.FeatureClass.Fields.get_Field(j).AliasName) == 0)
                                        return j;
                                }
                            }
                        }
                    }
                }
                if (o is IFields)
                {
                    IFields fields = (IFields)o;
                    if (!(fields == null))
                    {
                        int i = fields.FindField(FieldName);
                        if (i > -1)
                            return i;
                        else
                        {
                            for (int j = 0; j < fields.FieldCount; j++)
                            {
                                if (FieldName.CompareTo(fields.get_Field(j).AliasName) == 0)
                                    return j;
                            }
                        }
                    }
                }

                return -1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IFeatureClass NewShapefile(string location, string outputfeatureclassname, IFields outputfields)
        {
            if (outputfields == null)
                return null;

            IWorkspaceName outputworkspacename = new WorkspaceNameClass();
            outputworkspacename.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapeFileWorkspaceFactory.1";
            outputworkspacename.PathName = location;
            IName outputname = (IName)outputworkspacename;
            IWorkspace outputworkspace = (IWorkspace)outputname.Open();

            IFieldChecker outputfieldchecker = new FieldCheckerClass();
            outputfieldchecker.ValidateWorkspace = outputworkspace;

            IEnumFieldError enumfielderror;
            IClone clone = (IClone)outputfields;
            IFields clonefields = (IFields)clone.Clone();
            IFields newoutputfields;
            outputfieldchecker.Validate(clonefields, out enumfielderror, out newoutputfields);

            IFeatureClass outputfeatureclass;
            IFeatureWorkspace outputfeatureworkspace = (IFeatureWorkspace)outputworkspace;
            outputfeatureclass = outputfeatureworkspace.CreateFeatureClass(outputfeatureclassname, newoutputfields, null, null, esriFeatureType.esriFTSimple, "SHAPE", "");

            return outputfeatureclass;
        }

        public static bool DeleteShapefile(string filename)
        {
            try
            {
                FileInfo fileinfo;

                fileinfo = new FileInfo(filename + ".shp");
                if (fileinfo.Exists == true)
                    fileinfo.Delete();
                fileinfo = new FileInfo(filename + ".dbf");
                if (fileinfo.Exists == true)
                    fileinfo.Delete();
                fileinfo = new FileInfo(filename + ".prj");
                if (fileinfo.Exists == true)
                    fileinfo.Delete();
                fileinfo = new FileInfo(filename + ".sbn");
                if (fileinfo.Exists == true)
                    fileinfo.Delete();
                fileinfo = new FileInfo(filename + ".sbx");
                if (fileinfo.Exists == true)
                    fileinfo.Delete();
                fileinfo = new FileInfo(filename + ".shx");
                if (fileinfo.Exists == true)
                    fileinfo.Delete();
                fileinfo = new FileInfo(filename + ".shp.xml");
                if (fileinfo.Exists == true)
                    fileinfo.Delete();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool DoesShapefileExist(string filename)
        {
            try
            {
                FileInfo fileinfo;
                bool exists = true;

                fileinfo = new FileInfo(filename + ".shp");
                if (fileinfo.Exists != true)
                    exists = false;
                fileinfo = new FileInfo(filename + ".dbf");
                if (fileinfo.Exists != true)
                    exists = false;
                fileinfo = new FileInfo(filename + ".shx");
                if (fileinfo.Exists != true)
                    exists = false;
                return exists;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IPolygon EnvelopeToPolygon(IEnvelope2 envelope)
        {
            IGeometryBridge2 geometryBridge2 = new GeometryEnvironmentClass();
            IPointCollection4 pointCollection4 = new PolygonClass();

            WKSPoint[] aWKSPointBuffer = null;
            long cPoints = 4; //The number of points in the first part.
            aWKSPointBuffer = new WKSPoint[System.Convert.ToInt32(cPoints - 1) + 1];

            aWKSPointBuffer[0].X = envelope.XMin;
            aWKSPointBuffer[0].Y = envelope.YMin;
            aWKSPointBuffer[1].X = envelope.XMax;
            aWKSPointBuffer[1].Y = envelope.YMin;
            aWKSPointBuffer[2].X = envelope.XMax;
            aWKSPointBuffer[2].Y = envelope.YMax;
            aWKSPointBuffer[3].X = envelope.XMin;
            aWKSPointBuffer[3].Y = envelope.YMax;

            geometryBridge2.SetWKSPoints(pointCollection4, ref aWKSPointBuffer);

            IPolygon polygon = pointCollection4 as IPolygon;
            polygon.SimplifyPreserveFromTo();
            return polygon;
        }

        public static IPolygon PointsToPolygon(IPoint zero, IPoint one, IPoint two, IPoint three)
        {
            IGeometryBridge2 geometryBridge2 = new GeometryEnvironmentClass();
            IPointCollection4 pointCollection4 = new PolygonClass();

            WKSPoint[] aWKSPointBuffer = null;
            long cPoints = 4; //The number of points in the first part.
            aWKSPointBuffer = new WKSPoint[System.Convert.ToInt32(cPoints - 1) + 1];

            aWKSPointBuffer[0].X = zero.X;
            aWKSPointBuffer[0].Y = zero.Y;
            aWKSPointBuffer[1].X = one.X;
            aWKSPointBuffer[1].Y = one.Y;
            aWKSPointBuffer[2].X = two.X;
            aWKSPointBuffer[2].Y = two.Y;
            aWKSPointBuffer[3].X = three.X;
            aWKSPointBuffer[3].Y = three.Y;

            geometryBridge2.SetWKSPoints(pointCollection4, ref aWKSPointBuffer);

            IPolygon polygon = pointCollection4 as IPolygon;
            polygon.SimplifyPreserveFromTo();
            return polygon;
        }

        public static IPolygon EnvelopeToPolygon(IEnvelope envelope)
        {
            IGeometryBridge2 geometryBridge2 = new GeometryEnvironmentClass();
            IPointCollection4 pointCollection4 = new PolygonClass();

            WKSPoint[] aWKSPointBuffer = null;
            long cPoints = 4; //The number of points in the first part.
            aWKSPointBuffer = new WKSPoint[System.Convert.ToInt32(cPoints - 1) + 1];

            aWKSPointBuffer[0].X = envelope.XMin;
            aWKSPointBuffer[0].Y = envelope.YMin;
            aWKSPointBuffer[1].X = envelope.XMax;
            aWKSPointBuffer[1].Y = envelope.YMin;
            aWKSPointBuffer[2].X = envelope.XMax;
            aWKSPointBuffer[2].Y = envelope.YMax;
            aWKSPointBuffer[3].X = envelope.XMin;
            aWKSPointBuffer[3].Y = envelope.YMax;

            geometryBridge2.SetWKSPoints(pointCollection4, ref aWKSPointBuffer);

            IPolygon polygon = pointCollection4 as IPolygon;
            polygon.SimplifyPreserveFromTo();
            return polygon;
        }

        public static void AssignValues(ref IFeature row, string fieldname, object valueobject)
        {
            try
            {
                if (row == null) return;
                int index = FindField(row, fieldname);
                if (index == -1) return;

                IField field = row.Fields.get_Field(index);
                IDomain domain = field.Domain;
                if (domain != null)
                {
                    if (domain.Type == esriDomainType.esriDTCodedValue)
                    {
                        ICodedValueDomain codedvaluedomain = (ICodedValueDomain)domain;
                        int codecount = codedvaluedomain.CodeCount;
                        for (int i = 0; i < codecount; i++)
                        {
                            if (string.Compare(codedvaluedomain.get_Name(i), valueobject.ToString(), true) == 0)
                            {
                                valueobject = codedvaluedomain.get_Value(i);
                                break;
                            }
                        }
                    }
                    if (domain.Type == esriDomainType.esriDTRange)
                    {
                        IRangeDomain range = domain as IRangeDomain;
                        double minval = Convert.ToDouble(range.MinValue);
                        double maxval = Convert.ToDouble(range.MaxValue);
                        double value = Convert.ToDouble(valueobject);
                        if (value < minval) valueobject = (object)minval;
                        if (value > maxval) valueobject = (object)maxval;
                    }
                    if (domain.Type == esriDomainType.esriDTString)
                    {
                    }
                }

                string valueobjectstring = valueobject.ToString();
                switch (field.Type)
                {
                    case esriFieldType.esriFieldTypeBlob:
                        break;
                    case esriFieldType.esriFieldTypeDate:
                        DateTime datetime = Convert.ToDateTime(valueobjectstring);
                        string year = datetime.Year.ToString();
                        string month = datetime.Month.ToString();
                        string day = datetime.Day.ToString();
                        valueobjectstring = month + "/" + day + "/" + year;
                        row.set_Value(index, valueobjectstring);
                        break;
                    case esriFieldType.esriFieldTypeDouble:
                        double valueobjectdouble = Convert.ToDouble(valueobjectstring);
                        System.Math.Round(valueobjectdouble, 8);
                        row.set_Value(index, Convert.ToDouble(valueobjectstring));
                        break;
                    case esriFieldType.esriFieldTypeGeometry:
                        break;
                    case esriFieldType.esriFieldTypeGlobalID:
                        if (field.Length > valueobjectstring.Length)
                            row.set_Value(index, valueobject);
                        break;
                    case esriFieldType.esriFieldTypeGUID:
                        if (field.Length > valueobjectstring.Length)
                            row.set_Value(index, valueobject);
                        break;
                    case esriFieldType.esriFieldTypeInteger:
                        row.set_Value(index, Convert.ToInt64(valueobject));
                        break;
                    case esriFieldType.esriFieldTypeOID:
                        if (field.Length > valueobjectstring.Length)
                            row.set_Value(index, Convert.ToInt64(valueobject));
                        break;
                    case esriFieldType.esriFieldTypeRaster:
                        break;
                    case esriFieldType.esriFieldTypeSingle:
                        if (field.Length > valueobjectstring.Length)
                            row.set_Value(index, Convert.ToSingle(valueobject));
                        break;
                    case esriFieldType.esriFieldTypeSmallInteger:
                        if (field.Length > valueobjectstring.Length)
                            row.set_Value(index, Convert.ToInt16(valueobject));
                        break;
                    case esriFieldType.esriFieldTypeString:
                        if (field.Length < valueobjectstring.Length) valueobjectstring = valueobjectstring.Substring(0, field.Length - 1);
                        row.set_Value(index, valueobject.ToString());
                        break;
                    case esriFieldType.esriFieldTypeXML:
                        break;
                }

                row.Store();

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

    }
}
