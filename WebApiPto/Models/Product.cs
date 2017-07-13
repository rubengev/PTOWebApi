using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiPto.Models
{
    public class Product
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
    }



//    DECLARE @XmlData xml
//    DECLARE @PatientFormId int
// DECLARE @FormTypeId int
//DECLARE @PatientId varchar(20)


//    SET @PatientFormId = 0
//    SET @FormTypeId = 1
//    SET @PatientId = 'MP001'

//    SET @XmlData =
//            '<Questions>//                "<QuestionDto><Answer>dsrfyjhf</Answer><Checked>false</Checked><QuestionId>1</QuestionId></QuestionDto>"//                <QuestionDto>//                    <Answer/>//                    <Checked>true</Checked>//                    <QuestionId>2</QuestionId>//                </QuestionDto>//                <QuestionDto>//                    <Answer>ghfghfghfghfghfj</Answer>//                    <Checked>false</Checked>//                    <QuestionId>3</QuestionId>//                </QuestionDto>//            </Questions>'
  

//    DECLARE @Answer TABLE
//    (
//        PatientFormId   int,
//        QuestionId      int,
//        Checked bit DEFAULT 0,
//        Answer varchar(2000) DEFAULT ''
//    )
    
//    DECLARE @PatientForm TABLE
//    (
//        PatientFormId INT IDENTITY,
//        PatientId VARCHAR(20),
//        FormTypeId INT,
//        CreatedOn       SMALLDATETIME DEFAULT GETDATE()
//    )

//    IF @PatientFormId = 0
//        BEGIN
//            INSERT INTO @PatientForm(PatientId, FormTypeId) VALUES(@PatientId, @FormTypeId)
//            SET @PatientFormId = @@IDENTITY
//        END
//    ELSE
//       BEGIN
//            DELETE FROM @Answer WHERE PatientFormId = @PatientFormId
//            SELECT @PatientFormId
//       END


//     INSERT INTO @Answer(PatientFormId, QuestionId, Checked, Answer)
//        SELECT
//            @PatientFormId,
//            'QuestionId' = x.v.value('QuestionId[1]', 'int'),
//            'Checked' = x.v.value('Checked[1]', 'bit'),
//            'Answer' = x.v.value('Answer[1]', 'varchar(2000)')

//        FROM @XmlData.nodes('/Questions/QuestionDto') x(v)

//    SELECT* FROM @PatientForm
//    SELECT* FROM @Answer














}