using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
		public AudioSource music;

		//--------------------------------------------------------------------------------
		public AudioSource brake;
		public AudioSource click;
		public AudioSource item;
		public AudioSource countDown;
		public AudioSource crash;
		public AudioSource obstacleCrash;
		public AudioSource startEngine;
		public AudioSource preGameOver;

		//--------------------------------------------------------------------------------
		public AudioSource carFly;
		public AudioSource landed;

		//--------------------------------------------------------------------------------
		public AudioSource lose;
		public AudioSource win;

		//--------------------------------------------------------------------------------
		public AudioSource engine;
		public AudioSource engineNitro;
		public AudioSource police;

		//--------------------------------------------------------------------------------
		bool isMusicPlaying;
		bool isEnginePlaying;
		bool isEngineNitroPlaying;
		bool isPolicePlaying;
		bool isPreGameOverPlaying;

		void Start ()
		{
				music.clip = Resources.Load<AudioClip> ("Sound/BackGroundMusic/Sound_" + Random.Range (0, 8));	
		}

		public void playMusic ()
		{
				if (music.isPlaying == false) {
						music.volume = ProfileManager.setttings.MusicVolume / 100f;
						music.Play ();
				}
		}

		public void playEngine ()
		{
				if (engine.isPlaying == false) {
						engineNitro.Stop ();
						engine.volume = ProfileManager.setttings.SoundVolume / 100f;
						engine.Play ();
				}
		}

		public void playEngineNitro ()
		{
				if (engineNitro.isPlaying == false) {
						engine.Stop ();
						engineNitro.volume = ProfileManager.setttings.SoundVolume / 100f;
						engineNitro.Play ();
				}
		}

		public void playBrake ()
		{
				brake.Stop ();
				brake.volume = ProfileManager.setttings.SoundVolume / 100f;
				brake.Play ();
		}

		public void playClick ()
		{
				click.Stop ();
				click.volume = ProfileManager.setttings.SoundVolume / 100f;
				click.Play ();
		}

		public void playItem ()
		{
				item.Stop ();
				item.volume = ProfileManager.setttings.SoundVolume / 100f;
				item.Play ();
		}

		public void playCountDown ()
		{
				this.playStartEngine ();
				countDown.volume = ProfileManager.setttings.SoundVolume / 100f;
				countDown.Play ();
		}

		public void playPreGameOver ()
		{
				stopAllLoopSound ();
				preGameOver.volume = ProfileManager.setttings.SoundVolume / 100f;

				if (preGameOver.isPlaying == false) {
						preGameOver.Play ();
				}
		}

		public void playCrash ()
		{
				if (Game.gameState == Game.GAME_STATE.RUNNING) {
						if (crash.isPlaying == false) {
								crash.volume = ProfileManager.setttings.SoundVolume / 100f;
								crash.Play ();
						}
				}
		}

		public void playObstacleCrash ()
		{
				if (Game.gameState == Game.GAME_STATE.RUNNING) {
						if (obstacleCrash.isPlaying == false) {
								obstacleCrash.volume = ProfileManager.setttings.SoundVolume / 100f;
								obstacleCrash.Play ();
						}
				}
		}

		public void playStartEngine ()
		{
				startEngine.Stop ();
				startEngine.volume = ProfileManager.setttings.SoundVolume / 100f;
				startEngine.Play ();
		}

		public void playCarFly ()
		{
				if (Game.gameState == Game.GAME_STATE.RUNNING) {
						carFly.Stop ();
						carFly.volume = ProfileManager.setttings.SoundVolume / 100f;
						carFly.Play ();
				}
		}

		public void playLanded ()
		{
				if (Game.gameState == Game.GAME_STATE.RUNNING) {
						if (landed.isPlaying == false) {
								landed.volume = ProfileManager.setttings.SoundVolume / 100f;
								landed.Play ();
						}
				}
		}

		public void playLose ()
		{
				if (lose.isPlaying == false) {
						stopAllLoopSound ();
						lose.volume = ProfileManager.setttings.SoundVolume / 100f;
						lose.Play ();
				}
		}

		public void playWin ()
		{
				if (win.isPlaying == false) {
						stopAllLoopSound ();
						win.volume = ProfileManager.setttings.SoundVolume / 100f;
						win.Play ();
				}
		}

		public void playPolice ()
		{
				if (police.isPlaying == false) {
						police.volume = ProfileManager.setttings.SoundVolume / 100f;
						police.Play ();
				}
		}

		public void stopAllLoopSound ()
		{
				this.isMusicPlaying = music.isPlaying;
				this.isEnginePlaying = engine.isPlaying;
				this.isEngineNitroPlaying = engineNitro.isPlaying;
				this.isPolicePlaying = police.isPlaying;
				this.isPreGameOverPlaying = preGameOver.isPlaying;

				music.Stop ();
				engine.Stop ();
				engineNitro.Stop ();
				police.Stop ();
				preGameOver.Stop ();
		}

		public void replayAll ()
		{
				music.volume = ProfileManager.setttings.MusicVolume / 100f;

				engine.volume = ProfileManager.setttings.SoundVolume / 100f;
				engineNitro.volume = ProfileManager.setttings.SoundVolume / 100f;
				police.volume = ProfileManager.setttings.SoundVolume / 100f;

				preGameOver.volume = ProfileManager.setttings.MusicVolume / 100f;

				if (isMusicPlaying) {
						music.Play ();
				}

				if (isEnginePlaying) {
						engine.Play ();
				}

				if (isEngineNitroPlaying) {
						engineNitro.Play ();
				}

				if (isPolicePlaying) {
						police.Play ();
				}

				if (isPreGameOverPlaying) {
						preGameOver.Play ();
				}
		}
}