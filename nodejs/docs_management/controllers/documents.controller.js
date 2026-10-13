import {
  createDocument,
  getDocument,
  updateDocument,
  deleteDocument,
} from "../services/documents.service.js";
export const createDocumentsController = async (req, res) => {
  const document = await createDocument(
    req.body.author,
    req.body.title,
    req.body.description
  );
  res.send({ message: "Document created successfully", document });
};
export const getDocumentController = async (req, res) => {
  const id = req.params.id;
  const document = await getDocument(Number(id));
  if (document) {
    res.send({ message: "Document retrieved successfully", document });
  } else {
    res.send({ message: "Document not found" });
  }
};
export const updateDocumentController = async (req, res) => {
  const id = req.params.id;
  const author = req.body.newAuthor;
  const title = req.body.newTitle;
  const description = req.body.newDescription;
  const document = await updateDocument(id, author, title, description);
  if (document != 0) {
    res.send({ message: "Document updated successfully" });
  } else {
    res.send({ message: "Document not found" });
  }
};
export const deleteDocumentController = async (req, res) => {
  const id = req.params.id;
  const document = await deleteDocument(Number(id));
  if (document) {
    res.send({ message: "Document deleted successfully" });
  } else {
    res.send({ message: "Document not found" });
  }
};
