using DAY21_Assignment_MoodAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mood_Analyser;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_NULL_Mood_Should_Throw_MoodAnalysisException_Indicating_NullMood()
        {
            try
            {
                string message = null;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string mood = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be null", e.Message);
            }
        }



        [TestMethod]
        public void Given_ImproperClassName_Should_Throw_MoodAnalysisException_NO_SUCH_CLASS()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("WrongClass", "MoodAnalyser");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }

        [TestMethod]
        public void Given_ImproperConstructorName_Should_Throw_MoodAnalysisException_NO_SUCH_METHOD()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.MoodAnalyseObjectCreation("WrongConstructor", "WrongConstructor");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such Constructor found", e.Message);
            }
        }

        [TestMethod]
        public void Given_MoodAnalyserClassName_Should_ReturnMoodAnalyserObject_usingParameterisedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object actual = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "MoodAnalyser", "SAD");
            Assert.AreEqual(expected.GetType(), actual.GetType());
        }

        [TestMethod]
        public void Given_ImproperClassName_MoodAnalyserFactoryWithParameterisedConstructor_Should_ThrowMoodAnalysisException_NO_SUCH_CLASS()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("WrongClass", "MoodAnalyser", "SAD");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such class found", e.Message);
            }
        }

        [TestMethod]
        public void Given_ImproperConstructorName_MoodAnalyserFactoryWithParameterisedConstructor_Should_ThrowMoodAnalysisException_NO_SUCH_METHOD()
        {
            try
            {
                object expected = new MoodAnalyser();
                object actual = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyserApp.MoodAnalyser", "WrongConstructor", "HAPPY");
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("No such Constructor found", e.Message);
            }
        }

        [TestMethod]
        public void Given_Sad_MoodAnalyser_Should_Return_Sad()
        {
            //Arrange
            MoodAnalyser moodAnalyse = new MoodAnalyser("I am in a Sad mood");
            //Act
            string mood = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("SAD", mood);
        }

        [TestMethod]
        public void Given_Happy_MoodAnalyser_Should_Return_Happy()
        {
            //Arrange
            MoodAnalyser moodAnalyse = new MoodAnalyser("I am in a Happy mood");
            //Act
            string mood = moodAnalyse.AnalyseMood();
            //Assert
            Assert.AreEqual("HAPPY", mood);
        }

        [TestMethod]
        public void Given_Empty_Mood_Should_Throw_MoodAnalysisException_Indicating_EmptyMood()
        {
            try
            {
                string message = string.Empty;
                MoodAnalyser moodAnalyse = new MoodAnalyser(message);
                string moodStr = moodAnalyse.AnalyseMood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual("Mood should not be empty", e.Message);
            }
        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject()
        {
            string message = null;
            object expected = new MoodAnalyser(message);
            object obj = MoodAnalyserFactory.MoodAnalyseObjectCreation("MoodAnalyserAppWithCore.MoodAnalyser", "MoodAnalyser");
            // expected.Equals(obj);
            Assert.AreNotEqual(expected, obj);

        }
        [TestMethod]
        public void GivenMoodAnalyseClassName_ShouldReturnMoodAnalyseObject_UsingParameterizedConstructor()
        {
            object expected = new MoodAnalyser("HAPPY");
            object obj = MoodAnalyserFactory.CreateMoodAnalyserUsingParameterizedConstructor("MoodAnalyserAppWithCore.MoodAnalyser", "MoodAnalyser", "SAD");
            //expected.Equals(obj);
            Assert.AreNotEqual(expected, obj);
        }

        [TestMethod]
        public void GivenMoodHappy_ShouldReturnHappy()
        {
            MoodAnalyser obj = new MoodAnalyser("HAPPY");
            string result = obj.AnalyseMood();
            Assert.AreEqual("HAPPY", result);

        }

        [TestMethod]
        [ExpectedException(typeof(MoodAnalyserCustomException))]
        public void GivenMoodNull_ShouldThrowException()
        {
            MoodAnalyser obj = new MoodAnalyser(null);
            string result = obj.AnalyseMood();
            Assert.AreEqual("HAPPY", result);

        }


        [TestMethod]
        public void GivenMoodHappy_ShouldReturnNull()
        {
            MoodAnalyser obj = new MoodAnalyser("null");
            string result = obj.AnalyseMood();
            Assert.AreEqual("HAPPY", result);

        }

    }

    
   

}
