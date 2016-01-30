using UnityEngine;


public class WorldManager : MonoBehaviour {

	public GameObject[] worldPieces;

	public Vector3 spawnPosition;
	[Header("Do not use weird values plz")]
	public float moveSpeed = 0.5f;
	public float maxMoveDistance = 150;

	static WorldManager _instance;
	public static WorldManager instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = FindObjectOfType<WorldManager>();
			}
			return _instance;
		}
	}

	void Start()
	{
		StartGame();
	}

	void StartGame()
	{
	}


	public GameObject InstantiatePart()
	{
		int piece = Mathf.RoundToInt(Random.value * (worldPieces.Length-1));
		return InstantiatePart(piece);
	}
	/// <summary>
	/// if it's wanted, you can call upon a specific piece
	/// </summary>
	/// <param name="pieceID"></param>
	public GameObject InstantiatePart(int pieceID)
	{
		GameObject newPiece = Instantiate<GameObject>(worldPieces[pieceID]);
		newPiece.transform.position = spawnPosition;
		return newPiece;
	}
}
